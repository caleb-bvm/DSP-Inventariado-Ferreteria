using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioFerreteria.Models
{
    public class VarianteProducto
    {
        [Key]
        public int IdVariante { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un producto.")]
        public int IdProducto { get; set; }

        public int? IdMarca { get; set; }

        [Required(ErrorMessage = "El SKU es obligatorio.")]
        [StringLength(50, ErrorMessage = "El SKU no puede superar los 50 caracteres.")]
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
        [Range(typeof(decimal), "0.01", "99999999.99", ErrorMessage = "El precio de compra debe ser mayor que cero.")]
        public decimal PrecioCompra { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(typeof(decimal), "0.01", "99999999.99", ErrorMessage = "El precio de venta debe ser mayor que cero.")]
        public decimal PrecioVenta { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo.")]
        public int StockMinimo { get; set; }

        public bool Activo { get; set; } = true;

        [ForeignKey("IdProducto")]
        public Productos? Producto { get; set; }

        [ForeignKey("IdMarca")]
        public Marca? Marca { get; set; }
    }
}
