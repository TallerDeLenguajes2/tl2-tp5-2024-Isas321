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
}