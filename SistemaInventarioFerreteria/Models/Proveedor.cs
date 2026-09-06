using System.ComponentModel.DataAnnotations;

namespace SistemaInventarioFerreteria.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres.")]
        public string? Telefono { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        [StringLength(120, ErrorMessage = "El correo no puede superar los 120 caracteres.")]
        public string? Correo { get; set; }

        [StringLength(250, ErrorMessage = "La dirección no puede superar los 250 caracteres.")]
        public string? Direccion { get; set; }

        [Range(0, 365, ErrorMessage = "El tiempo de entrega debe estar entre 0 y 365 días.")]
        public int TiempoEntregaDias { get; set; } = 3;

        public bool Activo { get; set; } = true;
    }
}
