using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> inicio()
        {
            return View(await _context.Proveedores
                .OrderBy(p => p.Nombre)
                .ToListAsync());
        }

        public async Task<IActionResult> detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores
                .FirstOrDefaultAsync(p => p.IdProveedor == id);

            return proveedor == null ? NotFound() : View(proveedor);
        }

        public IActionResult crear()
        {
            return View(new Proveedor());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> crear(Proveedor proveedor)
        {
            Normalizar(proveedor);

            if (!ModelState.IsValid)
            {
                return View(proveedor);
            }

            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(inicio));
        }

        public async Task<IActionResult> editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores.FindAsync(id);
            return proveedor == null ? NotFound() : View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editar(int id, Proveedor proveedor)
        {
            if (id != proveedor.IdProveedor)
            {
                return NotFound();
            }

            Normalizar(proveedor);

            if (!ModelState.IsValid)
            {
                return View(proveedor);
            }

            _context.Proveedores.Update(proveedor);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(inicio));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Proveedores.AnyAsync(p => p.IdProveedor == id))
                {
                    return NotFound();
                }

                throw;
            }
        }

        public async Task<IActionResult> eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores
                .FirstOrDefaultAsync(p => p.IdProveedor == id);

            return proveedor == null ? NotFound() : View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> eliminar(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return RedirectToAction(nameof(inicio));
            }

            _context.Proveedores.Remove(proveedor);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(inicio));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty,
                    "No se puede eliminar el proveedor porque tiene entradas de inventario asociadas.");
                return View(proveedor);
            }
        }

        private static void Normalizar(Proveedor proveedor)
        {
            proveedor.Nombre = proveedor.Nombre?.Trim() ?? string.Empty;
            proveedor.Telefono = LimpiarOpcional(proveedor.Telefono);
            proveedor.Correo = LimpiarOpcional(proveedor.Correo);
            proveedor.Direccion = LimpiarOpcional(proveedor.Direccion);
        }

        private static string? LimpiarOpcional(string? valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }
    }
}
