using System.ComponentModel.DataAnnotations;

namespace SistemaInventarioFerreteria.Models
{
    public class PreguntaIa
    {
        [Required]
        [StringLength(300)]
        public string Pregunta { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int IdSucursal { get; set; }

        public int? IdVariante { get; set; }
    }
}
