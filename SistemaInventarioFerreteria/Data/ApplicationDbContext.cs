using Microsoft.EntityFrameworkCore;
using SistemaInventarioFerreteria.Models;

namespace SistemaInventarioFerreteria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<VarianteProducto> VariantesProducto { get; set; }

        public DbSet<Sucursal> Sucursales { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Inventario> Inventarios { get; set; }

		public DbSet<EntradaInventario> EntradasInventario { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Inventario>()
				.HasIndex(i => new { i.IdVariante, i.IdSucursal })
				.IsUnique();
		}
	}
}