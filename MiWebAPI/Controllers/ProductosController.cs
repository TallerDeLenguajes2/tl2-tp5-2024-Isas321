using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using MiWebAPI.Models;
using System.Net;
using MiWebAPI.Repositorios;
namespace MiWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductosController : ControllerBase
{
  [HttpPost("PostProductos", Name = "PostProductos")]
  public ActionResult PostProductos(string descripcion, int precio)
  {
      ProductosRepositorio productosRepositorio = new ProductosRepositorio();
      var producto = new Producto(descripcion, precio);
      productosRepositorio.Create(producto);
      return Ok("Producto creado correctamente");
  }


  [HttpGet("GetProductos", Name = "GetProductos")]
  public IEnumerable<Producto> GetProductos()
  {
    ProductosRepositorio produstosRepositorio = new ProductosRepositorio();
    return produstosRepositorio.GetAll();
  }


  [HttpGet("GetProductoPorId/{id}", Name = "GetProductoPorId/{id}")]
  public ActionResult<Producto> GetProductoById(int id)
  {
    ProductosRepositorio produstosRepositorio = new ProductosRepositorio();
    return produstosRepositorio.GetProductoPorId(id);
  }


  [HttpPut("PutProductos/{id}", Name = "PutProductos/{id}")]
  public ActionResult PutProductos(int id, Producto producto)
  {
    ProductosRepositorio productoRepositorio = new ProductosRepositorio();
    if(productoRepositorio.ActualizarProducto(id, producto)){
      return Ok("Modificado exitoso");
    } else{
      return BadRequest("No se pudo modificar");
    }
  }

  [HttpDelete("DeleteProductos/{id}", Name = "DeleteProductos/{id}")]
  public ActionResult DeleteProductos(int id)
  {
    ProductosRepositorio productoRepositorio = new ProductosRepositorio();
    if(productoRepositorio.Remove(id))
      return Ok("Producto eliminado");
    else
      return BadRequest("No se pudo eliminar el producto");
  }
}