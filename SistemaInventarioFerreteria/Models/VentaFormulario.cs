using System.ComponentModel.DataAnnotations;

namespace SistemaInventarioFerreteria.Models
{
    // Modelo sencillo para crear o editar una venta de un producto.
    public class VentaFormulario
    {
        public int IdVenta { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una sucursal.")]
        public int IdSucursal { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una variante.")]
        public int IdVariante { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Datos de presentación. La sucursal efectiva siempre se valida en el servidor.
        public bool SucursalFija { get; set; }
        public string? SucursalNombre { get; set; }
        public string? ProductoSeleccionadoNombre { get; set; }
        public string? ProductoSeleccionadoSku { get; set; }
        public int? ProductoSeleccionadoStock { get; set; }
        public decimal? ProductoSeleccionadoPrecio { get; set; }
    }
}
