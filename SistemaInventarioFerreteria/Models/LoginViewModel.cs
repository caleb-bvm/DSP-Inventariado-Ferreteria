using System.ComponentModel.DataAnnotations;

namespace SistemaInventarioFerreteria.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese el usuario.")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese la contraseña.")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = string.Empty;

        public bool Recordarme { get; set; }
    }
}
