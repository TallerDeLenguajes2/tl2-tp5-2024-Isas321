using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using MiWebAPI.Models;
using MiWebAPI.Repositorios;
using System.Net;
namespace MiWebAPI.Controllers;


[ApiController]
[Route("[controller]")]

public class PresupuestosController : ControllerBase
{
    private const string _cadenaDeConexion = "Data Source=db/Tienda.db";


    [HttpGet("/api/GetTablaPresupuestosPorId/{id}")]
    public ActionResult<List<Presupuesto>> GetTablaPresupuestosPorId(int id)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        return Ok(presupuestosRepositorio.ObtenerTablaPresupuestosPorId(id));
    }

    [HttpGet("/api/GetTablaPresupuestos")]
    public ActionResult<List<Presupuesto>> GetTablaPresupuestos()
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        return Ok(presupuestosRepositorio.ObtenerTablaPresupuestos());
    }

    [HttpGet("/api/GetPresupuesto/{id}", Name = "GetPresupuesto")]
    public ActionResult<Presupuesto> GetPresupuestoPorId(int id)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        var presupuesto = presupuestosRepositorio.ObtenerPorId(id);
        if(presupuesto == null)
            return NoContent(); // solicitud exitosa, no hay contenido para devolver al cliente.
        else
            return Ok(presupuesto);
    }

    [HttpGet("/api/GetPresupuestos", Name = "GetPresupuestos")]
    public ActionResult<List<Presupuesto>> GetPresupuestos()
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        return Ok(presupuestosRepositorio.ObtenerPresupuestoCompleto());
    }


    [HttpPost("/api/PostPresupuesto", Name = "PostPresupuesto")]
    public ActionResult PostPresupuesto(Presupuesto presupuesto)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        var id = presupuestosRepositorio.CrearPresupuestoVacio(presupuesto);
        return Ok($"Presupuesto creado con {id}");
    }

    [HttpPut("/api/PutPresupuestoAgregarProductoYcantidad/{id}")]
    public ActionResult PutPresupuesto(int id, Producto producto, int cantidad)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        if(presupuestosRepositorio.AgregarProductoYcantidad(id, producto, cantidad))
            return Ok("Presupuesto creado");
        else
            return BadRequest("No se pudo actualizar el detalle de presupuesto");
    }

    [HttpDelete("/api/DeletePresupuesto/{id}")]
    public ActionResult DeletePresupuesto(int id)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        if(presupuestosRepositorio.Eliminar(id))
            return Ok("Eliminado");
        else
            return BadRequest("No se pudo eliminar el presupuesto");
    }

    //No se que es lo que pide mas adelante
}