using Microsoft.VisualBasic;

namespace MiWebAPI.Models{
  public class Presupuesto{
    private int idPresupuesto;
    private string nombreDestinatario;
    private DateTime fechaCreacion;

    // public List<PresupuestoDetalle> Detalles { get; set; }

    public Presupuesto(int idPresupuesto, string nombreDestinatario, DateTime fechaCreacion)
    {
        this.idPresupuesto = idPresupuesto;
        this.nombreDestinatario = nombreDestinatario;
        this.fechaCreacion = fechaCreacion;
    }

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    
    public string MostrarPresupuesto(){
      return $"{idPresupuesto} {nombreDestinatario} {fechaCreacion}";
    }

    // private List<PresupuestoDetalle> presupuestoDetalles;

    //     public Presupuesto(int idPresupuesto, string nombreDestinatario, DateTime fechaCreacion, List<PresupuestoDetalle> presupuestoDetalles)
    //     {
    //         this.IdPresupuesto = idPresupuesto;
    //         this.NombreDestinatario = nombreDestinatario;
    //         this.FechaCreacion = fechaCreacion;
    //         this.PresupuestoDetalles = presupuestoDetalles;
    //     }

    //     public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    //     public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    //     public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    //     public List<PresupuestoDetalle> PresupuestoDetalles { get => presupuestoDetalles; set => presupuestoDetalles = value; }
    }
}