using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioFerreteria.Models
{
    public class DetalleVenta
    {
        [Key]
        public int IdDetalleVenta { get; set; }

        public int IdVenta { get; set; }

        public int IdVariante { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        [ForeignKey(nameof(IdVenta))]
        public Venta? Venta { get; set; }

        [ForeignKey(nameof(IdVariante))]
        public VarianteProducto? VarianteProducto { get; set; }
    }
}
