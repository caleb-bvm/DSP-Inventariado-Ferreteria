using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioFerreteria.Models
{
    public class VarianteProducto
    {
        [Key]
        public int IdVariante { get; set; }

        public int IdProducto { get; set; }

        public int? IdMarca { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Color { get; set; }

        [StringLength(50)]
        public string? Tamano { get; set; }

        [StringLength(80)]
        public string? Material { get; set; }

        [StringLength(80)]
        public string? Medida { get; set; }

        [StringLength(100)]
        public string? Presentacion { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioCompra { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioVenta { get; set; }

        public int StockMinimo { get; set; }

        public bool Activo { get; set; }

        [ForeignKey("IdProducto")]
        public Productos? Producto { get; set; }

        [ForeignKey("IdMarca")]
        public Marca? Marca { get; set; }
    }
}
