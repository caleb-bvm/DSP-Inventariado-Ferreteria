using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;

namespace SistemaInventarioFerreteria.Controllers
{
    public class AsistenteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsistenteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Sucursales = new SelectList(
                await _context.Sucursales.AsNoTracking()
                    .OrderBy(s => s.Nombre).ToListAsync(),
                "IdSucursal", "Nombre");

            var variantes = await _context.VariantesProducto
                .AsNoTracking()
                .Include(v => v.Producto)
                .Where(v => v.Activo)
                .OrderBy(v => v.SKU)
                .Select(v => new
                {
                    v.IdVariante,
                    Texto = v.SKU + " - " + v.Producto!.Nombre
                })
                .ToListAsync();

            ViewBag.Variantes = new SelectList(
                variantes, "IdVariante", "Texto");

            return View();
        }
    }
}
