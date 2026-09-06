using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
	public class InventariosController : Controller
	{
		private readonly ApplicationDbContext _context;

		public InventariosController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> inicio()
		{
			var inventarios = await _context.Inventarios
				.AsNoTracking()
				.Include(i => i.VarianteProducto)
					.ThenInclude(v => v!.Producto)
				.Include(i => i.Sucursal)
				.OrderBy(i => i.VarianteProducto!.SKU)
				.ThenBy(i => i.Sucursal!.Nombre)
				.ToListAsync();

			return View(inventarios);
		}

		public async Task<IActionResult> detalles(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var inventario = await ObtenerInventarioCompletoAsync(id.Value);
			return inventario == null ? NotFound() : View(inventario);
		}

		[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrador")]
		public async Task<IActionResult> crear()
		{
			await CargarListasAsync();
			return View(new Inventario());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrador")]
		public async Task<IActionResult> crear(
			[Bind("IdVariante,IdSucursal,Cantidad")] Inventario inventario)
		{
			await ValidarCombinacionUnicaAsync(inventario);

			if (!ModelState.IsValid)
			{
				await CargarListasAsync(
					inventario.IdVariante,
					inventario.IdSucursal);

				return View(inventario);
			}

			_context.Inventarios.Add(inventario);

			try
			{
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(inicio));
			}
			catch (DbUpdateException)
			{
				ModelState.AddModelError(
					string.Empty,
					"No fue posible guardar el inventario. Verifique que la variante y la sucursal no estén registradas juntas.");

				await CargarListasAsync(
					inventario.IdVariante,
					inventario.IdSucursal);

				return View(inventario);
			}
		}

		[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrador")]
		public async Task<IActionResult> editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var inventario = await _context.Inventarios.FindAsync(id.Value);

			if (inventario == null)
			{
				return NotFound();
			}

			await CargarListasAsync(
				inventario.IdVariante,
				inventario.IdSucursal);

			return View(inventario);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrador")]
		public async Task<IActionResult> editar(
			int id,
			[Bind("IdInventario,IdVariante,IdSucursal,Cantidad")]
			Inventario inventario)
		{
			if (id != inventario.IdInventario)
			{
				return NotFound();
			}

			await ValidarCombinacionUnicaAsync(inventario);

			if (!ModelState.IsValid)
			{
				await CargarListasAsync(
					inventario.IdVariante,
					inventario.IdSucursal);

				return View(inventario);
			}

			_context.Inventarios.Update(inventario);

			try
			{
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(inicio));
			}
			catch (DbUpdateConcurrencyException)
			{
				var existe = await _context.Inventarios
					.AnyAsync(i => i.IdInventario == id);

				if (!existe)
				{
					return NotFound();
				}

				throw;
			}
			catch (DbUpdateException)
			{
				ModelState.AddModelError(
					string.Empty,
					"No fue posible actualizar el inventario. Verifique que la variante y la sucursal no estén registradas juntas.");

				await CargarListasAsync(
					inventario.IdVariante,
					inventario.IdSucursal);

				return View(inventario);
			}
		}

		[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrador")]
		public async Task<IActionResult> eliminar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var inventario = await ObtenerInventarioCompletoAsync(id.Value);
			return inventario == null ? NotFound() : View(inventario);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrador")]
		public async Task<IActionResult> eliminar(int id)
		{
			var inventario = await ObtenerInventarioCompletoAsync(id);

			if (inventario == null)
			{
				return RedirectToAction(nameof(inicio));
			}

			_context.Inventarios.Remove(inventario);

			try
			{
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(inicio));
			}
			catch (DbUpdateException)
			{
				ModelState.AddModelError(
					string.Empty,
					"No fue posible eliminar este inventario porque está siendo utilizado por otro registro.");

				return View(inventario);
			}
		}

		private Task<Inventario?> ObtenerInventarioCompletoAsync(int id)
		{
			return _context.Inventarios
				.AsNoTracking()
				.Include(i => i.VarianteProducto)
					.ThenInclude(v => v!.Producto)
				.Include(i => i.Sucursal)
				.FirstOrDefaultAsync(i => i.IdInventario == id);
		}

		private async Task ValidarCombinacionUnicaAsync(
			Inventario inventario)
		{
			if (inventario.IdVariante <= 0 ||
				inventario.IdSucursal <= 0)
			{
				return;
			}

			var duplicado = await _context.Inventarios.AnyAsync(i =>
				i.IdVariante == inventario.IdVariante &&
				i.IdSucursal == inventario.IdSucursal &&
				i.IdInventario != inventario.IdInventario);

			if (duplicado)
			{
				ModelState.AddModelError(
					string.Empty,
					"Ya existe un inventario para la variante y la sucursal seleccionadas.");
			}
		}

		private async Task CargarListasAsync(
			int? idVariante = null,
			int? idSucursal = null)
		{
			var variantes = await _context.VariantesProducto
				.AsNoTracking()
				.Include(v => v.Producto)
				.OrderBy(v => v.SKU)
				.Select(v => new
				{
					v.IdVariante,
					Texto = v.SKU + " - " +
						(v.Producto != null
							? v.Producto.Nombre
							: "Sin producto")
				})
				.ToListAsync();

			var sucursales = await _context.Sucursales
				.AsNoTracking()
				.OrderBy(s => s.Nombre)
				.ToListAsync();

			ViewBag.Variantes = new SelectList(
				variantes,
				"IdVariante",
				"Texto",
				idVariante);

			ViewBag.Sucursales = new SelectList(
				sucursales,
				"IdSucursal",
				"Nombre",
				idSucursal);
		}
	}
}
