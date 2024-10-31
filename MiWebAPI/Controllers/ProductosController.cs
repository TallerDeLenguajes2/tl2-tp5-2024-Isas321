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
      ProductosRepositorio produstosRepositorio = new ProductosRepositorio();
      return produstosRepositorio.GetAll();
    }

  [HttpPost("PostProductos", Name = "PostProductos")]
  public IActionResult PostProductos(string descripcion, int precio)
  {
      ProductosRepositorio productosRepositorio = new ProductosRepositorio();
      var producto = new Producto(descripcion, precio);
      productosRepositorio.Create(producto);
      return Ok("Producto creado correctamente");
  }
}