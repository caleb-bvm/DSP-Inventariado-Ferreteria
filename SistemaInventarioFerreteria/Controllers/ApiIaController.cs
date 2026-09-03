using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;
using SistemaInventarioFerreteria.Services;

namespace SistemaInventarioFerreteria.Controllers
{
    [ApiController]
    [Route("api/ia")]
    public class ApiIaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IaService _iaService;

        public ApiIaController(ApplicationDbContext context, IaService iaService)
        {
            _context = context;
            _iaService = iaService;
        }

        [HttpPost("preguntar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<RespuestaIa>> Preguntar(PreguntaIa solicitud)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var sucursal = await _context.Sucursales
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.IdSucursal == solicitud.IdSucursal);

            if (sucursal == null)
            {
                return BadRequest("La sucursal seleccionada no existe.");
            }

            var pregunta = solicitud.Pregunta.ToLowerInvariant();
            RespuestaIa respuesta;

            if (pregunta.Contains("resumen") || pregunta.Contains("alertas"))
            {
                respuesta = await ResumirAlertasAsync(solicitud.IdSucursal, sucursal.Nombre);
            }
            else if (pregunta.Contains("reposici") || pregunta.Contains("explica"))
            {
                respuesta = await ExplicarReposicionAsync(solicitud, sucursal.Nombre);
            }
            else
            {
                respuesta = await ConsultarDisponibilidadAsync(solicitud, sucursal.Nombre);
            }

            var explicacionIa = await _iaService.ExplicarAsync(
                solicitud.Pregunta,
                $"{respuesta.Evidencia}. {respuesta.Calculo}");

            if (!string.IsNullOrWhiteSpace(explicacionIa))
            {
                respuesta.Respuesta = explicacionIa;
                respuesta.GeneradaPorIa = true;
                respuesta.Aviso = "Contenido generado por IA a partir de datos calculados por el sistema. No modifica el inventario.";
            }
            else
            {
                respuesta.Aviso = "Respuesta local verificable. Configure su API key de OpenAI para habilitar la explicación generativa. No modifica el inventario.";
            }

            return Ok(respuesta);
        }

        private async Task<RespuestaIa> ConsultarDisponibilidadAsync(
            PreguntaIa solicitud, string nombreSucursal)
        {
            if (!solicitud.IdVariante.HasValue)
            {
                return new RespuestaIa
                {
                    Respuesta = "Seleccione una variante para consultar su disponibilidad.",
                    Evidencia = $"Sucursal consultada: {nombreSucursal}",
                    Calculo = "No se realizó un cálculo porque falta la variante."
                };
            }

            var inventario = await _context.Inventarios
                .AsNoTracking()
                .Include(i => i.VarianteProducto)
                    .ThenInclude(v => v!.Producto)
                .FirstOrDefaultAsync(i =>
                    i.IdSucursal == solicitud.IdSucursal &&
                    i.IdVariante == solicitud.IdVariante.Value);

            if (inventario == null)
            {
                return new RespuestaIa
                {
                    Respuesta = "La variante no tiene inventario registrado en esta sucursal.",
                    Evidencia = $"Sucursal: {nombreSucursal}",
                    Calculo = "Sin registro de inventario."
                };
            }

            var producto = inventario.VarianteProducto?.Producto?.Nombre ?? "Producto";
            var sku = inventario.VarianteProducto?.SKU ?? "Sin SKU";

            return new RespuestaIa
            {
                Respuesta = inventario.Cantidad > 0
                    ? $"Hay {inventario.Cantidad} unidades disponibles de {producto}."
                    : $"{producto} no tiene existencias disponibles.",
                Evidencia = $"Sucursal: {nombreSucursal}; SKU: {sku}; existencias: {inventario.Cantidad}",
                Calculo = "Disponibilidad = cantidad actual registrada en Inventarios."
            };
        }

        private async Task<RespuestaIa> ExplicarReposicionAsync(
            PreguntaIa solicitud, string nombreSucursal)
        {
            if (!solicitud.IdVariante.HasValue)
            {
                return new RespuestaIa
                {
                    Respuesta = "Seleccione una variante para explicar su reposición.",
                    Evidencia = $"Sucursal consultada: {nombreSucursal}",
                    Calculo = "No se realizó un cálculo porque falta la variante."
                };
            }

            var inventario = await _context.Inventarios
                .AsNoTracking()
                .Include(i => i.VarianteProducto)
                    .ThenInclude(v => v!.Producto)
                .FirstOrDefaultAsync(i =>
                    i.IdSucursal == solicitud.IdSucursal &&
                    i.IdVariante == solicitud.IdVariante.Value);

            if (inventario == null)
            {
                return new RespuestaIa
                {
                    Respuesta = "No hay datos suficientes para calcular una reposición.",
                    Evidencia = $"Sucursal: {nombreSucursal}; variante sin inventario",
                    Calculo = "Datos insuficientes."
                };
            }

            var desde = DateTime.Now.AddDays(-30);
            var unidadesVendidas = await _context.DetalleVentas
                .Where(d => d.IdVariante == solicitud.IdVariante.Value &&
                    d.Venta!.IdSucursal == solicitud.IdSucursal &&
                    d.Venta.Fecha >= desde)
                .SumAsync(d => (int?)d.Cantidad) ?? 0;

            var promedioDiario = unidadesVendidas / 30m;
            var stockMinimo = inventario.VarianteProducto?.StockMinimo ?? 0;
            var objetivo = Math.Ceiling(promedioDiario * 14) + stockMinimo;
            var recomendada = Math.Max(0, (int)objetivo - inventario.Cantidad);
            var producto = inventario.VarianteProducto?.Producto?.Nombre ?? "Producto";

            return new RespuestaIa
            {
                Respuesta = recomendada > 0
                    ? $"Se sugiere revisar una reposición de {recomendada} unidades de {producto}."
                    : $"{producto} tiene existencias suficientes para el objetivo de 14 días.",
                Evidencia = $"Sucursal: {nombreSucursal}; stock actual: {inventario.Cantidad}; ventas de 30 días: {unidadesVendidas}; stock mínimo: {stockMinimo}",
                Calculo = $"Promedio diario = {unidadesVendidas} / 30 = {promedioDiario:0.00}. Recomendación = máx(0, promedio × 14 + stock mínimo - stock actual) = {recomendada}."
            };
        }

        private async Task<RespuestaIa> ResumirAlertasAsync(
            int idSucursal, string nombreSucursal)
        {
            var inventarios = await _context.Inventarios
                .AsNoTracking()
                .Include(i => i.VarianteProducto)
                    .ThenInclude(v => v!.Producto)
                .Where(i => i.IdSucursal == idSucursal &&
                    i.Cantidad <= i.VarianteProducto!.StockMinimo)
                .OrderBy(i => i.Cantidad)
                .ToListAsync();

            if (inventarios.Count == 0)
            {
                return new RespuestaIa
                {
                    Respuesta = $"{nombreSucursal} no tiene alertas de stock bajo.",
                    Evidencia = "No hay existencias iguales o menores al stock mínimo.",
                    Calculo = "Alerta = stock actual ≤ stock mínimo."
                };
            }

            var productos = string.Join(", ", inventarios.Take(5).Select(i =>
                $"{i.VarianteProducto!.Producto!.Nombre} ({i.Cantidad})"));

            return new RespuestaIa
            {
                Respuesta = $"Hay {inventarios.Count} alertas de stock bajo. Prioridad: {productos}.",
                Evidencia = $"Sucursal: {nombreSucursal}; registros revisados al {DateTime.Now:dd/MM/yyyy HH:mm}",
                Calculo = "Se cuentan las variantes cuyo stock actual es menor o igual a su stock mínimo."
            };
        }
    }
}
