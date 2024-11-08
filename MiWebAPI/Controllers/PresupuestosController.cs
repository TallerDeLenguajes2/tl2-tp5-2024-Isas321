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
    [HttpGet("GetPresupuestos", Name = "GetPresupuestos")]
    public ActionResult<List<Presupuesto>> GetPresupuestos()
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio();
        return presupuestosRepositorio.ObtenerTodos();
    }

    [HttpGet("GetPresupuesto/{id}", Name = "GetPresupuesto/{id}")]
    public ActionResult<Presupuesto> GetPresupuestoPorId(int id)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio();
        return presupuestosRepositorio.ObtenerPresupuestoPorId(id);
    }

    [HttpPost("PostPresupuesto", Name = "PostPresupuesto")]
    public ActionResult PostPresupuesto(Presupuesto presupuesto)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio();
        presupuestosRepositorio.Crear(presupuesto);
        return Ok("Presupuesto creado");
    }

    [HttpPut("PutPresupuesto/{id}", Name = "PutPresupuesto/{id}")]
    public ActionResult PostPresupuesto(int id, Producto producto, int cantidad)
    {
        PresupuestosRepositorio presupuestosRepositorio = new PresupuestosRepositorio();
        if(presupuestosRepositorio.Actualizar(id, producto, cantidad))
            return Ok("Presupuesto creado");
        else
            return BadRequest("No se pudo actualizar el detalle de presupuesto");
    }

    //No se que es lo que pide mas adelante
}