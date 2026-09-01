using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucursalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> inicio()
        {
            return View(await _context.Sucursales
                .OrderBy(s => s.Nombre)
                .ToListAsync());
        }

        public async Task<IActionResult> detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursales
                .FirstOrDefaultAsync(s => s.IdSucursal == id);

            return sucursal == null ? NotFound() : View(sucursal);
        }

        public IActionResult crear()
        {
            return View(new Sucursal());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> crear(Sucursal sucursal)
        {
            Normalizar(sucursal);

            if (!ModelState.IsValid)
            {
                return View(sucursal);
            }

            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(inicio));
        }

        public async Task<IActionResult> editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursales.FindAsync(id);
            return sucursal == null ? NotFound() : View(sucursal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editar(int id, Sucursal sucursal)
        {
            if (id != sucursal.IdSucursal)
            {
                return NotFound();
            }

            Normalizar(sucursal);

            if (!ModelState.IsValid)
            {
                return View(sucursal);
            }

            _context.Sucursales.Update(sucursal);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(inicio));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Sucursales.AnyAsync(s => s.IdSucursal == id))
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

            var sucursal = await _context.Sucursales
                .FirstOrDefaultAsync(s => s.IdSucursal == id);

            return sucursal == null ? NotFound() : View(sucursal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> eliminar(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);

            if (sucursal == null)
            {
                return RedirectToAction(nameof(inicio));
            }

            _context.Sucursales.Remove(sucursal);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(inicio));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty,
                    "No se puede eliminar la sucursal porque tiene movimientos de inventario asociados.");
                return View(sucursal);
            }
        }

        private static void Normalizar(Sucursal sucursal)
        {
            sucursal.Nombre = sucursal.Nombre?.Trim() ?? string.Empty;
            sucursal.Direccion = LimpiarOpcional(sucursal.Direccion);
            sucursal.Telefono = LimpiarOpcional(sucursal.Telefono);
        }

        private static string? LimpiarOpcional(string? valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? null : valor.Trim();
        }
    }
}
