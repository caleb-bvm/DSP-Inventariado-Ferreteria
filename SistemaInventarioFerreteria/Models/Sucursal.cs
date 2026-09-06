using System.ComponentModel.DataAnnotations;

namespace SistemaInventarioFerreteria.Models
{
    public class Sucursal
    {
        [Key]
        public int IdSucursal { get; set; }

        [Required(ErrorMessage = "El nombre de la sucursal es obligatorio.")]
        [StringLength(120, ErrorMessage = "El nombre no puede superar los 120 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "La dirección no puede superar los 250 caracteres.")]
        public string? Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres.")]
        public string? Telefono { get; set; }

        public bool Activo { get; set; } = true;
    }
}
