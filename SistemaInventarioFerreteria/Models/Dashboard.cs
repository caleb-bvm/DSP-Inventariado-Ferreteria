namespace SistemaInventarioFerreteria.Models
{
    public class Dashboard
    {
        public int TotalProductos { get; set; }

        public int TotalCategorias { get; set; }

        public int TotalProveedores { get; set; }

        public int TotalSucursales { get; set; }

        public int TotalExistencias { get; set; }

        public int StockBajo { get; set; }
    }
}
