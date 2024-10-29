namespace EspacioTienda
{
  public class Producto
  {
        private int idProducto;
        private string descripcion;
        private int precio;

        public Producto(int idProducto, string descripcion, int precio)
        {
            this.idProducto = idProducto;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public int IdProducto { get => idProducto; }
        public string Descripcion { get => descripcion; }
        public int Precio { get => precio; }


    public string MostrarProducto(){
      return $"\n\tIdProducto [id]: {idProducto}\n\tDescricion: {descripcion}\n\tPrecio: {precio}\n";
    }
  }
}