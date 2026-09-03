using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioFerreteria.Models
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una sucursal.")]
        public int IdSucursal { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [ForeignKey(nameof(IdSucursal))]
        public Sucursal? Sucursal { get; set; }

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
