namespace MiWebAPI.ViewModels
{
    public class PresupuestoCompleto
    {
        public class PresupuestoCompletoViewModel
        {
            public PresupuestoCompletoViewModel(int idPresupuesto, string nombreDestinatario, DateTime fechaCreacion, List<ProductoDetalleViewModel> productos)
            {
                IdPresupuesto = idPresupuesto;
                NombreDestinatario = nombreDestinatario;
                FechaCreacion = fechaCreacion;
                Productos = productos;
            }

            public int IdPresupuesto { get; set; }
            public string NombreDestinatario { get; set; }
            public DateTime FechaCreacion { get; set; }
            public List<ProductoDetalleViewModel> Productos { get; set; }
        }

        public class ProductoDetalleViewModel
        {
            public ProductoDetalleViewModel(int idProducto, string descripcion, decimal precio, int cantidad)
            {
                IdProducto = idProducto;
                Descripcion = descripcion;
                Precio = precio;
                Cantidad = cantidad;
            }

            public int IdProducto { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
        }
    }
}