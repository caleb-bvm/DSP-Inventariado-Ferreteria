using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Data;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Controllers
{
	public class EntradasInventarioController : Controller
	{
		private readonly ApplicationDbContext _context;

		public EntradasInventarioController(
			ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> inicio()
		{
			var entradas = await _context.EntradasInventario
				.AsNoTracking()
				.Include(e => e.VarianteProducto)
					.ThenInclude(v => v!.Producto)
				.Include(e => e.Sucursal)
				.Include(e => e.Proveedor)
				.OrderByDescending(e => e.Fecha)
				.ThenByDescending(e => e.IdEntrada)
				.ToListAsync();

			return View(entradas);
		}

		public async Task<IActionResult> detalles(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var entrada = await ObtenerEntradaCompletaAsync(id.Value);
			return entrada == null ? NotFound() : View(entrada);
		}

		public async Task<IActionResult> crear()
		{
			await CargarListasAsync();

			return View(new EntradaInventario
			{
				Fecha = DateTime.Now
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> crear(
			[Bind("IdVariante,IdSucursal,IdProveedor,Cantidad,CostoUnitario,Fecha")]
			EntradaInventario entrada)
		{
			await ValidarReferenciasAsync(entrada);

			if (!ModelState.IsValid)
			{
				await CargarListasAsync(
					entrada.IdVariante,
					entrada.IdSucursal,
					entrada.IdProveedor);

				return View(entrada);
			}

			var datos = new
			{
				entrada.IdVariante,
				entrada.IdSucursal,
				entrada.IdProveedor,
				entrada.Cantidad,
				entrada.CostoUnitario,
				entrada.Fecha
			};

			try
			{
				var strategy = _context.Database
					.CreateExecutionStrategy();

				await strategy.ExecuteAsync(async () =>
				{
					_context.ChangeTracker.Clear();

					await using var transaction =
						await _context.Database.BeginTransactionAsync(
							IsolationLevel.Serializable);

					var inventario =
						await ObtenerOCrearInventarioAsync(
							datos.IdVariante,
							datos.IdSucursal);

					inventario.Cantidad = CalcularCantidad(
						inventario.Cantidad,
						datos.Cantidad);

					_context.EntradasInventario.Add(
						new EntradaInventario
						{
							IdVariante = datos.IdVariante,
							IdSucursal = datos.IdSucursal,
							IdProveedor = datos.IdProveedor,
							Cantidad = datos.Cantidad,
							CostoUnitario = datos.CostoUnitario,
							Fecha = datos.Fecha
						});

					await _context.SaveChangesAsync();
					await transaction.CommitAsync();
				});

				return RedirectToAction(nameof(inicio));
			}
			catch (OperacionInventarioException ex)
			{
				_context.ChangeTracker.Clear();
				ModelState.AddModelError(string.Empty, ex.Message);
			}
			catch (DbUpdateException)
			{
				_context.ChangeTracker.Clear();

				ModelState.AddModelError(
					string.Empty,
					"No fue posible registrar la entrada. Verifique los datos seleccionados.");
			}

			await CargarListasAsync(
				entrada.IdVariante,
				entrada.IdSucursal,
				entrada.IdProveedor);

			return View(entrada);
		}

		public async Task<IActionResult> editar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var entrada = await _context.EntradasInventario
				.AsNoTracking()
				.FirstOrDefaultAsync(
					e => e.IdEntrada == id.Value);

			if (entrada == null)
			{
				return NotFound();
			}

			await CargarListasAsync(
				entrada.IdVariante,
				entrada.IdSucursal,
				entrada.IdProveedor);

			return View(entrada);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> editar(
			int id,
			[Bind("IdEntrada,IdVariante,IdSucursal,IdProveedor,Cantidad,CostoUnitario,Fecha")]
			EntradaInventario entrada)
		{
			if (id != entrada.IdEntrada)
			{
				return NotFound();
			}

			var existe = await _context.EntradasInventario
				.AnyAsync(e => e.IdEntrada == id);

			if (!existe)
			{
				return NotFound();
			}

			await ValidarReferenciasAsync(entrada);

			if (!ModelState.IsValid)
			{
				await CargarListasAsync(
					entrada.IdVariante,
					entrada.IdSucursal,
					entrada.IdProveedor);

				return View(entrada);
			}

			var datos = new
			{
				entrada.IdEntrada,
				entrada.IdVariante,
				entrada.IdSucursal,
				entrada.IdProveedor,
				entrada.Cantidad,
				entrada.CostoUnitario,
				entrada.Fecha
			};

			try
			{
				var strategy = _context.Database
					.CreateExecutionStrategy();

				await strategy.ExecuteAsync(async () =>
				{
					_context.ChangeTracker.Clear();

					await using var transaction =
						await _context.Database.BeginTransactionAsync(
							IsolationLevel.Serializable);

					var original =
						await _context.EntradasInventario
							.FirstOrDefaultAsync(
								e => e.IdEntrada == datos.IdEntrada)
						?? throw new OperacionInventarioException(
							"La entrada ya no existe.");

					var mismaUbicacion =
						original.IdVariante == datos.IdVariante &&
						original.IdSucursal == datos.IdSucursal;

					if (mismaUbicacion)
					{
						var inventario =
							await _context.Inventarios
								.SingleOrDefaultAsync(i =>
									i.IdVariante ==
										original.IdVariante &&
									i.IdSucursal ==
										original.IdSucursal)
							?? throw new OperacionInventarioException(
								"No existe el inventario asociado a la entrada original.");

						var diferencia =
							datos.Cantidad - original.Cantidad;

						inventario.Cantidad = CalcularCantidad(
							inventario.Cantidad,
							diferencia);
					}
					else
					{
						var inventarioAnterior =
							await _context.Inventarios
								.SingleOrDefaultAsync(i =>
									i.IdVariante ==
										original.IdVariante &&
									i.IdSucursal ==
										original.IdSucursal)
							?? throw new OperacionInventarioException(
								"No existe el inventario asociado a la entrada original.");

						inventarioAnterior.Cantidad =
							CalcularCantidad(
								inventarioAnterior.Cantidad,
								-original.Cantidad);

						var inventarioNuevo =
							await ObtenerOCrearInventarioAsync(
								datos.IdVariante,
								datos.IdSucursal);

						inventarioNuevo.Cantidad =
							CalcularCantidad(
								inventarioNuevo.Cantidad,
								datos.Cantidad);
					}

					original.IdVariante = datos.IdVariante;
					original.IdSucursal = datos.IdSucursal;
					original.IdProveedor = datos.IdProveedor;
					original.Cantidad = datos.Cantidad;
					original.CostoUnitario =
						datos.CostoUnitario;
					original.Fecha = datos.Fecha;

					await _context.SaveChangesAsync();
					await transaction.CommitAsync();
				});

				return RedirectToAction(nameof(inicio));
			}
			catch (OperacionInventarioException ex)
			{
				_context.ChangeTracker.Clear();
				ModelState.AddModelError(string.Empty, ex.Message);
			}
			catch (DbUpdateException)
			{
				_context.ChangeTracker.Clear();

				ModelState.AddModelError(
					string.Empty,
					"No fue posible actualizar la entrada. Verifique los datos seleccionados.");
			}

			await CargarListasAsync(
				entrada.IdVariante,
				entrada.IdSucursal,
				entrada.IdProveedor);

			return View(entrada);
		}

		public async Task<IActionResult> eliminar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var entrada = await ObtenerEntradaCompletaAsync(id.Value);
			return entrada == null ? NotFound() : View(entrada);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> eliminar(int id)
		{
			var existe = await _context.EntradasInventario
				.AnyAsync(e => e.IdEntrada == id);

			if (!existe)
			{
				return RedirectToAction(nameof(inicio));
			}

			try
			{
				var strategy = _context.Database
					.CreateExecutionStrategy();

				await strategy.ExecuteAsync(async () =>
				{
					_context.ChangeTracker.Clear();

					await using var transaction =
						await _context.Database.BeginTransactionAsync(
							IsolationLevel.Serializable);

					var entrada =
						await _context.EntradasInventario
							.FirstOrDefaultAsync(
								e => e.IdEntrada == id)
						?? throw new OperacionInventarioException(
							"La entrada ya no existe.");

					var inventario =
						await _context.Inventarios
							.SingleOrDefaultAsync(i =>
								i.IdVariante ==
									entrada.IdVariante &&
								i.IdSucursal ==
									entrada.IdSucursal)
						?? throw new OperacionInventarioException(
							"No existe el inventario asociado a esta entrada.");

					inventario.Cantidad = CalcularCantidad(
						inventario.Cantidad,
						-entrada.Cantidad);

					_context.EntradasInventario.Remove(entrada);

					await _context.SaveChangesAsync();
					await transaction.CommitAsync();
				});

				return RedirectToAction(nameof(inicio));
			}
			catch (OperacionInventarioException ex)
			{
				_context.ChangeTracker.Clear();
				ModelState.AddModelError(string.Empty, ex.Message);
			}
			catch (DbUpdateException)
			{
				_context.ChangeTracker.Clear();

				ModelState.AddModelError(
					string.Empty,
					"No fue posible eliminar la entrada.");
			}

			var entradaConError =
				await ObtenerEntradaCompletaAsync(id);

			return entradaConError == null
				? NotFound()
				: View(entradaConError);
		}

		private Task<EntradaInventario?>
			ObtenerEntradaCompletaAsync(int id)
		{
			return _context.EntradasInventario
				.AsNoTracking()
				.Include(e => e.VarianteProducto)
					.ThenInclude(v => v!.Producto)
				.Include(e => e.Sucursal)
				.Include(e => e.Proveedor)
				.FirstOrDefaultAsync(
					e => e.IdEntrada == id);
		}

		private async Task<Inventario>
			ObtenerOCrearInventarioAsync(
				int idVariante,
				int idSucursal)
		{
			var inventario = await _context.Inventarios
				.SingleOrDefaultAsync(i =>
					i.IdVariante == idVariante &&
					i.IdSucursal == idSucursal);

			if (inventario != null)
			{
				return inventario;
			}

			inventario = new Inventario
			{
				IdVariante = idVariante,
				IdSucursal = idSucursal,
				Cantidad = 0
			};

			_context.Inventarios.Add(inventario);

			return inventario;
		}

		private async Task ValidarReferenciasAsync(
			EntradaInventario entrada)
		{
			if (entrada.IdVariante > 0 &&
				!await _context.VariantesProducto.AnyAsync(
					v => v.IdVariante == entrada.IdVariante))
			{
				ModelState.AddModelError(
					nameof(EntradaInventario.IdVariante),
					"La variante seleccionada no existe.");
			}

			if (entrada.IdSucursal > 0 &&
				!await _context.Sucursales.AnyAsync(
					s => s.IdSucursal == entrada.IdSucursal))
			{
				ModelState.AddModelError(
					nameof(EntradaInventario.IdSucursal),
					"La sucursal seleccionada no existe.");
			}

			if (entrada.IdProveedor.HasValue &&
				!await _context.Proveedores.AnyAsync(
					p => p.IdProveedor ==
						entrada.IdProveedor.Value))
			{
				ModelState.AddModelError(
					nameof(EntradaInventario.IdProveedor),
					"El proveedor seleccionado no existe.");
			}
		}

		private async Task CargarListasAsync(
			int? idVariante = null,
			int? idSucursal = null,
			int? idProveedor = null)
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

			var proveedores = await _context.Proveedores
				.AsNoTracking()
				.OrderBy(p => p.Nombre)
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

			ViewBag.Proveedores = new SelectList(
				proveedores,
				"IdProveedor",
				"Nombre",
				idProveedor);
		}

		private static int CalcularCantidad(
			int cantidadActual,
			int cambio)
		{
			var resultado = (long)cantidadActual + cambio;

			if (resultado < 0)
			{
				throw new OperacionInventarioException(
					"La operación fue rechazada porque dejaría existencias negativas.");
			}

			if (resultado > int.MaxValue)
			{
				throw new OperacionInventarioException(
					"La cantidad resultante supera el máximo permitido.");
			}

			return (int)resultado;
		}

		private sealed class OperacionInventarioException :
			Exception
		{
			public OperacionInventarioException(string message)
				: base(message)
			{
			}
		}
	}
}