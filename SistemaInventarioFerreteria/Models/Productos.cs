using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventarioFerreteria.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        public int IdCategoria { get; set; }

        public bool Activo { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }
    }
}
