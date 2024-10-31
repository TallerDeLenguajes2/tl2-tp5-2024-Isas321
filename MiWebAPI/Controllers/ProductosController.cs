using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using MiWebAPI.Models;
using System.Net;
using MiWebAPI.Repositorios;
namespace MiWebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductosController : ControllerBase
{
    [HttpGet("GetProductos", Name = "GetProductos")]
    public IEnumerable<Producto> GetProductos()
    {
      ProductosRepositorio prodRepo = new ProductosRepositorio();
      return prodRepo.GetAll();
    }
}