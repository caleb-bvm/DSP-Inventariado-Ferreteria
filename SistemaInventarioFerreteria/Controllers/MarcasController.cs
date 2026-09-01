using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
    public class MarcasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarcasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> inicio()
        {
            return View(await _context.Marcas
                .OrderBy(m => m.Nombre)
                .ToListAsync());
        }

        public async Task<IActionResult> detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marcas
                .FirstOrDefaultAsync(m => m.IdMarca == id);

            return marca == null ? NotFound() : View(marca);
        }

        public IActionResult crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> crear(Marca marca)
        {
            marca.Nombre = marca.Nombre?.Trim() ?? string.Empty;
            await ValidarNombreAsync(marca);

            if (!ModelState.IsValid)
            {
                return View(marca);
            }

            _context.Marcas.Add(marca);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(inicio));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(nameof(Marca.Nombre),
                    "No fue posible guardar la marca. Verifique que el nombre no esté registrado.");
                return View(marca);
            }
        }

        public async Task<IActionResult> editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marcas.FindAsync(id);
            return marca == null ? NotFound() : View(marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editar(int id, Marca marca)
        {
            if (id != marca.IdMarca)
            {
                return NotFound();
            }

            marca.Nombre = marca.Nombre?.Trim() ?? string.Empty;
            await ValidarNombreAsync(marca);

            if (!ModelState.IsValid)
            {
                return View(marca);
            }

            _context.Marcas.Update(marca);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(inicio));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Marcas.AnyAsync(m => m.IdMarca == id))
                {
                    return NotFound();
                }

                throw;
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(nameof(Marca.Nombre),
                    "No fue posible actualizar la marca. Verifique que el nombre no esté registrado.");
                return View(marca);
            }
        }

        public async Task<IActionResult> eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marcas
                .FirstOrDefaultAsync(m => m.IdMarca == id);

            return marca == null ? NotFound() : View(marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> eliminar(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return RedirectToAction(nameof(inicio));
            }

            _context.Marcas.Remove(marca);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(inicio));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty,
                    "No se puede eliminar la marca porque está asociada a uno o más productos.");
                return View(marca);
            }
        }

        private async Task ValidarNombreAsync(Marca marca)
        {
            if (string.IsNullOrWhiteSpace(marca.Nombre))
            {
                ModelState.AddModelError(nameof(Marca.Nombre),
                    "El nombre de la marca es obligatorio.");
                return;
            }

            var nombreDuplicado = await _context.Marcas.AnyAsync(m =>
                m.IdMarca != marca.IdMarca && m.Nombre == marca.Nombre);

            if (nombreDuplicado)
            {
                ModelState.AddModelError(nameof(Marca.Nombre),
                    "Ya existe una marca con este nombre.");
            }
        }
    }
}
