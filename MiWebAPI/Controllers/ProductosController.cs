using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using EspacioTienda;
using System.Net;
namespace MiWebAPI.Controllers;


[ApiController]
[Route("[controller]")]

public class ProductosController : ControllerBase
{
      [HttpGet("GetProductos", Name = "GetProductos")]
    public IEnumerable<Producto> GetProductos()
    {
        List<Producto> productos = new List<Producto>();
        var cadena = "Data Source = db/Tienda.db";
        using( var sqlitecon = new SqliteConnection(cadena)){
        // Importante crear y destruir!
        sqlitecon.Open();
        var consulta = @"SELECT * FROM Productos;";
        SqliteCommand comand = new SqliteCommand(consulta, sqlitecon);
        var reader = comand.ExecuteReader();
        while(reader.Read())
        {
            var Id = Convert.ToInt32(reader["idProducto"]);
            var Nombre = reader["Descripcion"].ToString();
            var Precio = Convert.ToInt32(reader["Precio"]);
            var producto = new Producto(Id, Nombre, Precio);
            productos.Add(producto);
        }
        sqlitecon.Close(); //Me aseguro que la BD queda liberada
        }
        return productos;
    }
}