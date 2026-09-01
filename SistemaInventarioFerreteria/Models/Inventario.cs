using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioFerreteria.Models
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }

        public int IdVariante { get; set; }

        public int IdSucursal { get; set; }

        public int Cantidad { get; set; }

        [ForeignKey("IdVariante")]
        public VarianteProducto? VarianteProducto { get; set; }

        [ForeignKey("IdSucursal")]
        public Sucursal? Sucursal { get; set; }
    }
}
