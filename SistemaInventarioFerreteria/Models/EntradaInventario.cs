using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioFerreteria.Models
{
	public class EntradaInventario
	{
		[Key]
		public int IdEntrada { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Seleccione una variante.")]
		public int IdVariante { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Seleccione una sucursal.")]
		public int IdSucursal { get; set; }

		public int? IdProveedor { get; set; }

		[Range(1, int.MaxValue,
			ErrorMessage = "La cantidad debe ser mayor que cero.")]
		public int Cantidad { get; set; }

		[Column(TypeName = "decimal(10,2)")]
		[Range(typeof(decimal), "0.01", "99999999.99",
			ErrorMessage = "El costo unitario debe ser mayor que cero.")]
		public decimal CostoUnitario { get; set; }

		[Required(ErrorMessage = "La fecha es obligatoria.")]
		[Column(TypeName = "datetime")]
		public DateTime Fecha { get; set; } = DateTime.Now;

		[ForeignKey(nameof(IdVariante))]
		public VarianteProducto? VarianteProducto { get; set; }

		[ForeignKey(nameof(IdSucursal))]
		public Sucursal? Sucursal { get; set; }

		[ForeignKey(nameof(IdProveedor))]
		public Proveedor? Proveedor { get; set; }
	}
}