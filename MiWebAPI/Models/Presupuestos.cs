using Microsoft.VisualBasic;

namespace EspacioTienda{
  public class Presupuesto{
    private int idPresupuesto;
    private string nombreDestinatario;
    private DateFormat fechaCreacion;

    public Presupuesto(int idPresupuesto, string nombreDestinatario, DateFormat fechaCreacion)
    {
        this.IdPresupuesto = idPresupuesto;
        this.NombreDestinatario = nombreDestinatario;
        this.FechaCreacion = fechaCreacion;
    }

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public DateFormat FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    public string MostrarPresupuesto(){
      return $"{idPresupuesto} {nombreDestinatario} {fechaCreacion}";
    }
  }
}