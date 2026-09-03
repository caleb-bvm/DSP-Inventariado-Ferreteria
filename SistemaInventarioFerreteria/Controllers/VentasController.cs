using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> inicio()
        {
            var ventas = await _context.Ventas
                .AsNoTracking()
                .Include(v => v.Sucursal)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.VarianteProducto)
                        .ThenInclude(v => v!.Producto)
                .OrderByDescending(v => v.Fecha)
                .ToListAsync();

            return View(ventas);
        }

        public async Task<IActionResult> detalles(int? id)
        {
            if (id == null) return NotFound();

            var venta = await ObtenerCompletaAsync(id.Value);
            return venta == null ? NotFound() : View(venta);
        }

        public async Task<IActionResult> crear()
        {
            await CargarListasAsync();
            return View(new VentaFormulario());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> crear(VentaFormulario modelo)
        {
            await ValidarReferenciasAsync(modelo);

            if (!ModelState.IsValid)
            {
                await CargarListasAsync(modelo.IdSucursal, modelo.IdVariante);
                return View(modelo);
            }

            await using var transaccion = await _context.Database
                .BeginTransactionAsync(IsolationLevel.Serializable);

            try
            {
                var variante = await _context.VariantesProducto
                    .FindAsync(modelo.IdVariante);
                var inventario = await ObtenerInventarioAsync(
                    modelo.IdSucursal, modelo.IdVariante);

                if (variante == null || inventario == null ||
                    inventario.Cantidad < modelo.Cantidad)
                {
                    throw new InvalidOperationException(
                        "No hay suficientes existencias para registrar la venta.");
                }

                var subtotal = variante.PrecioVenta * modelo.Cantidad;
                var venta = new Venta
                {
                    IdSucursal = modelo.IdSucursal,
                    Fecha = modelo.Fecha,
                    Total = subtotal
                };

                venta.Detalles.Add(new DetalleVenta
                {
                    IdVariante = modelo.IdVariante,
                    Cantidad = modelo.Cantidad,
                    PrecioUnitario = variante.PrecioVenta,
                    Subtotal = subtotal
                });

                inventario.Cantidad -= modelo.Cantidad;
                _context.Ventas.Add(venta);

                await _context.SaveChangesAsync();
                await transaccion.CommitAsync();

                return RedirectToAction(nameof(inicio));
            }
            catch (InvalidOperationException ex)
            {
                await transaccion.RollbackAsync();
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (DbUpdateException)
            {
                await transaccion.RollbackAsync();
                ModelState.AddModelError(string.Empty,
                    "No fue posible registrar la venta. Verifique los datos.");
            }

            await CargarListasAsync(modelo.IdSucursal, modelo.IdVariante);
            return View(modelo);
        }

        public async Task<IActionResult> editar(int? id)
        {
            if (id == null) return NotFound();

            var venta = await ObtenerCompletaAsync(id.Value);
            if (venta == null) return NotFound();

            var detalle = venta.Detalles.FirstOrDefault();
            if (detalle == null) return NotFound();

            var modelo = new VentaFormulario
            {
                IdVenta = venta.IdVenta,
                IdSucursal = venta.IdSucursal,
                IdVariante = detalle.IdVariante,
                Cantidad = detalle.Cantidad,
                Fecha = venta.Fecha
            };

            await CargarListasAsync(modelo.IdSucursal, modelo.IdVariante);
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editar(int id, VentaFormulario modelo)
        {
            if (id != modelo.IdVenta) return NotFound();

            await ValidarReferenciasAsync(modelo);

            if (!ModelState.IsValid)
            {
                await CargarListasAsync(modelo.IdSucursal, modelo.IdVariante);
                return View(modelo);
            }

            await using var transaccion = await _context.Database
                .BeginTransactionAsync(IsolationLevel.Serializable);

            try
            {
                var venta = await _context.Ventas
                    .Include(v => v.Detalles)
                    .FirstOrDefaultAsync(v => v.IdVenta == id);

                if (venta == null || venta.Detalles.Count != 1)
                {
                    throw new InvalidOperationException(
                        "Esta venta no se puede editar desde el formulario sencillo.");
                }

                var detalle = venta.Detalles.First();
                var inventarioAnterior = await ObtenerInventarioAsync(
                    venta.IdSucursal, detalle.IdVariante);

                if (inventarioAnterior == null)
                {
                    throw new InvalidOperationException(
                        "No se encontró el inventario original de la venta.");
                }

                // Primero se devuelve la cantidad anterior y luego se aplica la nueva.
                inventarioAnterior.Cantidad += detalle.Cantidad;

                var inventarioNuevo = await ObtenerInventarioAsync(
                    modelo.IdSucursal, modelo.IdVariante);
                var variante = await _context.VariantesProducto
                    .FindAsync(modelo.IdVariante);

                if (inventarioNuevo == null || variante == null ||
                    inventarioNuevo.Cantidad < modelo.Cantidad)
                {
                    throw new InvalidOperationException(
                        "No hay suficientes existencias para actualizar la venta.");
                }

                inventarioNuevo.Cantidad -= modelo.Cantidad;
                var subtotal = variante.PrecioVenta * modelo.Cantidad;

                venta.IdSucursal = modelo.IdSucursal;
                venta.Fecha = modelo.Fecha;
                venta.Total = subtotal;
                detalle.IdVariante = modelo.IdVariante;
                detalle.Cantidad = modelo.Cantidad;
                detalle.PrecioUnitario = variante.PrecioVenta;
                detalle.Subtotal = subtotal;

                await _context.SaveChangesAsync();
                await transaccion.CommitAsync();

                return RedirectToAction(nameof(inicio));
            }
            catch (InvalidOperationException ex)
            {
                await transaccion.RollbackAsync();
                _context.ChangeTracker.Clear();
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (DbUpdateException)
            {
                await transaccion.RollbackAsync();
                _context.ChangeTracker.Clear();
                ModelState.AddModelError(string.Empty,
                    "No fue posible actualizar la venta.");
            }

            await CargarListasAsync(modelo.IdSucursal, modelo.IdVariante);
            return View(modelo);
        }

        public async Task<IActionResult> eliminar(int? id)
        {
            if (id == null) return NotFound();

            var venta = await ObtenerCompletaAsync(id.Value);
            return venta == null ? NotFound() : View(venta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> eliminar(int id)
        {
            await using var transaccion = await _context.Database
                .BeginTransactionAsync(IsolationLevel.Serializable);

            try
            {
                var venta = await _context.Ventas
                    .Include(v => v.Detalles)
                    .FirstOrDefaultAsync(v => v.IdVenta == id);

                if (venta == null) return RedirectToAction(nameof(inicio));

                foreach (var detalle in venta.Detalles)
                {
                    var inventario = await ObtenerInventarioAsync(
                        venta.IdSucursal, detalle.IdVariante);

                    if (inventario != null)
                    {
                        inventario.Cantidad += detalle.Cantidad;
                    }
                }

                _context.DetalleVentas.RemoveRange(venta.Detalles);
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
                await transaccion.CommitAsync();

                return RedirectToAction(nameof(inicio));
            }
            catch (DbUpdateException)
            {
                await transaccion.RollbackAsync();
                ModelState.AddModelError(string.Empty,
                    "No fue posible eliminar la venta.");
            }

            var ventaConError = await ObtenerCompletaAsync(id);
            return ventaConError == null ? NotFound() : View(ventaConError);
        }

        private Task<Venta?> ObtenerCompletaAsync(int id)
        {
            return _context.Ventas
                .AsNoTracking()
                .Include(v => v.Sucursal)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.VarianteProducto)
                        .ThenInclude(v => v!.Producto)
                .FirstOrDefaultAsync(v => v.IdVenta == id);
        }

        private Task<Inventario?> ObtenerInventarioAsync(int idSucursal, int idVariante)
        {
            return _context.Inventarios.SingleOrDefaultAsync(i =>
                i.IdSucursal == idSucursal && i.IdVariante == idVariante);
        }

        private async Task ValidarReferenciasAsync(VentaFormulario modelo)
        {
            if (modelo.IdSucursal > 0 &&
                !await _context.Sucursales.AnyAsync(s => s.IdSucursal == modelo.IdSucursal))
            {
                ModelState.AddModelError(nameof(modelo.IdSucursal),
                    "La sucursal seleccionada no existe.");
            }

            if (modelo.IdVariante > 0 &&
                !await _context.VariantesProducto.AnyAsync(v => v.IdVariante == modelo.IdVariante))
            {
                ModelState.AddModelError(nameof(modelo.IdVariante),
                    "La variante seleccionada no existe.");
            }
        }

        private async Task CargarListasAsync(int? idSucursal = null, int? idVariante = null)
        {
            ViewBag.Sucursales = new SelectList(
                await _context.Sucursales.AsNoTracking().OrderBy(s => s.Nombre).ToListAsync(),
                "IdSucursal", "Nombre", idSucursal);

            var variantes = await _context.VariantesProducto
                .AsNoTracking()
                .Include(v => v.Producto)
                .Where(v => v.Activo)
                .OrderBy(v => v.SKU)
                .Select(v => new
                {
                    v.IdVariante,
                    Texto = v.SKU + " - " + v.Producto!.Nombre +
                        " ($" + v.PrecioVenta.ToString("0.00") + ")"
                })
                .ToListAsync();

            ViewBag.Variantes = new SelectList(
                variantes, "IdVariante", "Texto", idVariante);
        }
    }
}
