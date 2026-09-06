using System.Data;
using System.Security.Claims;
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
            var consulta = _context.Ventas
                .AsNoTracking()
                .Include(v => v.Sucursal)
                .Include(v => v.Detalles)
                    .ThenInclude(d => d.VarianteProducto)
                        .ThenInclude(v => v!.Producto)
                .AsQueryable();

            var idSucursalOperador = ObtenerSucursalOperador();
            if (User.IsInRole("Operador"))
            {
                if (!idSucursalOperador.HasValue) return Forbid();
                consulta = consulta.Where(v =>
                    v.IdSucursal == idSucursalOperador.Value);
                ViewBag.SucursalOperador = User.FindFirstValue("SucursalNombre");
            }

            var ventas = await consulta
                .OrderByDescending(v => v.Fecha)
                .ToListAsync();

            return View(ventas);
        }

        public async Task<IActionResult> detalles(int? id)
        {
            if (id == null) return NotFound();

            var venta = await ObtenerCompletaAsync(id.Value);
            return venta == null || !PuedeAcceder(venta.IdSucursal)
                ? NotFound()
                : View(venta);
        }

        public async Task<IActionResult> crear()
        {
            var modelo = new VentaFormulario();
            if (!AplicarSucursalOperador(modelo)) return Forbid();

            await CargarFormularioAsync(modelo);
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> crear(VentaFormulario modelo)
        {
            if (!AplicarSucursalOperador(modelo)) return Forbid();
            await ValidarReferenciasAsync(modelo);

            if (!ModelState.IsValid)
            {
                await CargarFormularioAsync(modelo);
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

            await CargarFormularioAsync(modelo);
            return View(modelo);
        }

        public async Task<IActionResult> editar(int? id)
        {
            if (id == null) return NotFound();

            var venta = await ObtenerCompletaAsync(id.Value);
            if (venta == null || !PuedeAcceder(venta.IdSucursal)) return NotFound();

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

            AplicarSucursalOperador(modelo);
            await CargarFormularioAsync(modelo);
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editar(int id, VentaFormulario modelo)
        {
            if (id != modelo.IdVenta) return NotFound();

            var idSucursalOriginal = await _context.Ventas
                .AsNoTracking()
                .Where(v => v.IdVenta == id)
                .Select(v => (int?)v.IdSucursal)
                .FirstOrDefaultAsync();
            if (!idSucursalOriginal.HasValue ||
                !PuedeAcceder(idSucursalOriginal.Value)) return NotFound();

            if (!AplicarSucursalOperador(modelo)) return Forbid();
            await ValidarReferenciasAsync(modelo);

            if (!ModelState.IsValid)
            {
                await CargarFormularioAsync(modelo);
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

            await CargarFormularioAsync(modelo);
            return View(modelo);
        }

        public async Task<IActionResult> eliminar(int? id)
        {
            if (id == null) return NotFound();

            var venta = await ObtenerCompletaAsync(id.Value);
            return venta == null || !PuedeAcceder(venta.IdSucursal)
                ? NotFound()
                : View(venta);
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
                if (!PuedeAcceder(venta.IdSucursal)) return NotFound();

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

        [HttpGet]
        public async Task<IActionResult> buscarProductos(
            string? termino, int? idSucursal)
        {
            var sucursal = User.IsInRole("Operador")
                ? ObtenerSucursalOperador()
                : idSucursal;

            if (!sucursal.HasValue || sucursal.Value <= 0)
            {
                return BadRequest(new { mensaje = "Seleccione una sucursal." });
            }

            var consulta = _context.Inventarios
                .AsNoTracking()
                .Where(i => i.IdSucursal == sucursal.Value &&
                    i.Cantidad > 0 &&
                    i.VarianteProducto!.Activo &&
                    i.VarianteProducto.Producto!.Activo);

            var texto = termino?.Trim();
            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(i =>
                    i.VarianteProducto!.SKU.Contains(texto) ||
                    i.VarianteProducto.Producto!.Nombre.Contains(texto));
            }

            var productos = await consulta
                .OrderBy(i => i.VarianteProducto!.Producto!.Nombre)
                .ThenBy(i => i.VarianteProducto!.SKU)
                .Take(12)
                .Select(i => new
                {
                    id = i.IdVariante,
                    nombre = i.VarianteProducto!.Producto!.Nombre,
                    sku = i.VarianteProducto.SKU,
                    detalle = i.VarianteProducto.Presentacion ??
                        i.VarianteProducto.Medida ??
                        i.VarianteProducto.Tamano ?? "Producto",
                    precio = i.VarianteProducto.PrecioVenta,
                    existencia = i.Cantidad
                })
                .ToListAsync();

            return Json(productos);
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
                !await _context.Sucursales.AnyAsync(s =>
                    s.IdSucursal == modelo.IdSucursal && s.Activo))
            {
                ModelState.AddModelError(nameof(modelo.IdSucursal),
                    "La sucursal seleccionada no existe o está inactiva.");
            }

            if (modelo.IdVariante > 0 &&
                !await _context.Inventarios.AnyAsync(i =>
                    i.IdSucursal == modelo.IdSucursal &&
                    i.IdVariante == modelo.IdVariante &&
                    i.VarianteProducto!.Activo &&
                    i.VarianteProducto.Producto!.Activo))
            {
                ModelState.AddModelError(nameof(modelo.IdVariante),
                    "El producto no está disponible en esta sucursal.");
            }
        }

        private async Task CargarFormularioAsync(VentaFormulario modelo)
        {
            modelo.SucursalFija = User.IsInRole("Operador");
            if (modelo.SucursalFija)
            {
                modelo.SucursalNombre = User.FindFirstValue("SucursalNombre") ??
                    await _context.Sucursales
                        .Where(s => s.IdSucursal == modelo.IdSucursal)
                        .Select(s => s.Nombre)
                        .FirstOrDefaultAsync();
            }
            else
            {
                ViewBag.Sucursales = new SelectList(
                    await _context.Sucursales
                        .AsNoTracking()
                        .Where(s => s.Activo)
                        .OrderBy(s => s.Nombre)
                        .ToListAsync(),
                    "IdSucursal", "Nombre", modelo.IdSucursal);
            }

            if (modelo.IdSucursal <= 0 || modelo.IdVariante <= 0) return;

            var producto = await _context.Inventarios
                .AsNoTracking()
                .Where(i => i.IdSucursal == modelo.IdSucursal &&
                    i.IdVariante == modelo.IdVariante)
                .Select(i => new
                {
                    Nombre = i.VarianteProducto!.Producto!.Nombre,
                    i.VarianteProducto.SKU,
                    Stock = i.Cantidad,
                    Precio = i.VarianteProducto.PrecioVenta
                })
                .FirstOrDefaultAsync();

            if (producto == null) return;

            modelo.ProductoSeleccionadoNombre = producto.Nombre;
            modelo.ProductoSeleccionadoSku = producto.SKU;
            modelo.ProductoSeleccionadoStock = producto.Stock;
            modelo.ProductoSeleccionadoPrecio = producto.Precio;
        }

        private int? ObtenerSucursalOperador()
        {
            var valor = User.FindFirstValue("SucursalId");
            return int.TryParse(valor, out var idSucursal)
                ? idSucursal
                : null;
        }

        private bool AplicarSucursalOperador(VentaFormulario modelo)
        {
            if (!User.IsInRole("Operador")) return true;

            var idSucursal = ObtenerSucursalOperador();
            if (!idSucursal.HasValue) return false;

            ModelState.Remove(nameof(modelo.IdSucursal));
            modelo.IdSucursal = idSucursal.Value;
            return true;
        }

        private bool PuedeAcceder(int idSucursal)
        {
            return User.IsInRole("Administrador") ||
                ObtenerSucursalOperador() == idSucursal;
        }
    }
}
