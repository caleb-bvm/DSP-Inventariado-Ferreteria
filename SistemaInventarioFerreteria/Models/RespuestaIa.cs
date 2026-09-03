namespace SistemaInventarioFerreteria.Models
{
    public class RespuestaIa
    {
        public string Respuesta { get; set; } = string.Empty;

        public string Evidencia { get; set; } = string.Empty;

        public string Calculo { get; set; } = string.Empty;

        public bool GeneradaPorIa { get; set; }

        public string Aviso { get; set; } =
            "La respuesta es informativa y no modifica el inventario.";
    }
}
