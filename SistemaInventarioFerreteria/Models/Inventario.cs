using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioFerreteria.Models
{
    public class Inventario
    {
		[Key]
		public int IdInventario { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Seleccione una variante.")]
		public int IdVariante { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Seleccione una sucursal.")]
		public int IdSucursal { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa.")]
		public int Cantidad { get; set; }

		[ForeignKey("IdVariante")]
		public VarianteProducto? VarianteProducto { get; set; }

		[ForeignKey("IdSucursal")]
		public Sucursal? Sucursal { get; set; }
	}
}
