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

    [HttpGet("/api/GetPresupuestos", Name = "GetPresupuestos")]
    public ActionResult<List<Presupuesto>> GetPresupuestos()
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        return Ok(presupuestosRepositorio.ObtenerTodos());
    }


    [HttpGet("/api/GetPresupuesto/{id}", Name = "GetPresupuesto")]
    public ActionResult<Presupuesto> GetPresupuestoPorId(int id)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        var presupuesto = presupuestosRepositorio.ObtenerPresupuestoPorId(id);
        if(presupuesto == null)
            return NoContent(); // solicitud exitosa, no hay contenido para devolver al cliente.
        else
            return Ok(presupuesto);
    }

    [HttpGet("/api/GetPresupuestoCompleto/{id}", Name = "GetPresupuestoCompleto")]
    public ActionResult<Presupuesto> GetPresupuestoCompletoPorId(int id)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        var presupuesto = presupuestosRepositorio.ObtenerPresupuestoCompletoPorId(id);
        if(presupuesto == null)
            return NoContent(); // solicitud exitosa, no hay contenido para devolver al cliente.
        else
            return Ok(presupuesto);
    }

    [HttpPost("/api/PostPresupuesto", Name = "PostPresupuesto")]
    public ActionResult PostPresupuesto(Presupuesto presupuesto)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        presupuestosRepositorio.Crear(presupuesto);
        return Ok("Presupuesto creado");
    }

    [HttpPut("/api/PutPresupuesto/{id}", Name = "PutPresupuesto")]
    public ActionResult PostPresupuesto(int id, Producto producto, int cantidad)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio(_cadenaDeConexion);
        if(presupuestosRepositorio.Actualizar(id, producto, cantidad))
            return Ok("Presupuesto creado");
        else
            return BadRequest("No se pudo actualizar el detalle de presupuesto");
    }

    //No se que es lo que pide mas adelante
}