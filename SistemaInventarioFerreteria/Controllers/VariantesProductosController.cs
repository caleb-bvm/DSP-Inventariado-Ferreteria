using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class VariantesProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VariantesProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> inicio()
        {
            var variantes = await _context.VariantesProducto
                .AsNoTracking()
                .Include(v => v.Producto)
                .Include(v => v.Marca)
                .OrderBy(v => v.SKU)
                .ToListAsync();

            return View(variantes);
        }

        public async Task<IActionResult> detalles(int? id)
        {
            if (id == null) return NotFound();

            var variante = await ObtenerCompletaAsync(id.Value);
            return variante == null ? NotFound() : View(variante);
        }

        public async Task<IActionResult> crear()
        {
            await CargarListasAsync();
            return View(new VarianteProducto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> crear(VarianteProducto variante)
        {
            await ValidarSkuAsync(variante);

            if (!ModelState.IsValid)
            {
                await CargarListasAsync(variante.IdProducto, variante.IdMarca);
                return View(variante);
            }

            variante.SKU = variante.SKU.Trim().ToUpperInvariant();
            _context.VariantesProducto.Add(variante);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(inicio));
        }

        public async Task<IActionResult> editar(int? id)
        {
            if (id == null) return NotFound();

            var variante = await _context.VariantesProducto.FindAsync(id.Value);
            if (variante == null) return NotFound();

            await CargarListasAsync(variante.IdProducto, variante.IdMarca);
            return View(variante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editar(int id, VarianteProducto variante)
        {
            if (id != variante.IdVariante) return NotFound();

            await ValidarSkuAsync(variante);

            if (!ModelState.IsValid)
            {
                await CargarListasAsync(variante.IdProducto, variante.IdMarca);
                return View(variante);
            }

            variante.SKU = variante.SKU.Trim().ToUpperInvariant();
            _context.VariantesProducto.Update(variante);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(inicio));
        }

        public async Task<IActionResult> eliminar(int? id)
        {
            if (id == null) return NotFound();

            var variante = await ObtenerCompletaAsync(id.Value);
            return variante == null ? NotFound() : View(variante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> eliminar(int id)
        {
            var variante = await ObtenerCompletaAsync(id);
            if (variante == null) return RedirectToAction(nameof(inicio));

            var enUso = await _context.Inventarios.AnyAsync(i => i.IdVariante == id) ||
                await _context.EntradasInventario.AnyAsync(e => e.IdVariante == id) ||
                await _context.DetalleVentas.AnyAsync(d => d.IdVariante == id);

            if (enUso)
            {
                ModelState.AddModelError(string.Empty,
                    "No se puede eliminar porque la variante tiene movimientos registrados. Puede marcarla como inactiva.");
                return View(variante);
            }

            _context.VariantesProducto.Remove(variante);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(inicio));
        }

        private Task<VarianteProducto?> ObtenerCompletaAsync(int id)
        {
            return _context.VariantesProducto
                .AsNoTracking()
                .Include(v => v.Producto)
                .Include(v => v.Marca)
                .FirstOrDefaultAsync(v => v.IdVariante == id);
        }

        private async Task ValidarSkuAsync(VarianteProducto variante)
        {
            var sku = variante.SKU.Trim();
            var repetido = await _context.VariantesProducto.AnyAsync(v =>
                v.SKU == sku && v.IdVariante != variante.IdVariante);

            if (repetido)
            {
                ModelState.AddModelError(nameof(VarianteProducto.SKU),
                    "Ya existe una variante con este SKU.");
            }
        }

        private async Task CargarListasAsync(int? idProducto = null, int? idMarca = null)
        {
            ViewBag.Productos = new SelectList(
                await _context.Productos.AsNoTracking().OrderBy(p => p.Nombre).ToListAsync(),
                "IdProducto", "Nombre", idProducto);

            ViewBag.Marcas = new SelectList(
                await _context.Marcas.AsNoTracking().OrderBy(m => m.Nombre).ToListAsync(),
                "IdMarca", "Nombre", idMarca);
        }
    }
}
