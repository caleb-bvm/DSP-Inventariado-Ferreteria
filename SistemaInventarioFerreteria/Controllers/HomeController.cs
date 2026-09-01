using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;


namespace SistemaInventarioFerreteria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dashboard = new Dashboard();

            dashboard.TotalProductos =
                await _context.Productos.CountAsync();

            dashboard.TotalCategorias =
                await _context.Categorias.CountAsync();

            dashboard.TotalProveedores =
                await _context.Proveedores.CountAsync();

            dashboard.TotalSucursales =
                await _context.Sucursales.CountAsync();

            dashboard.TotalExistencias = await _context.Inventarios.SumAsync(i => i.Cantidad);

            return View(dashboard);
        }
    }
}