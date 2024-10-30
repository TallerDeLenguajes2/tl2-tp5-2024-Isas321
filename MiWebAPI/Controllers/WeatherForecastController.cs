using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using EspacioTienda;

namespace MiWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProductos")]
    public IEnumerable<Producto> Get()
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


    
    // [HttpGet(Name = "GetPresupuestos")]
    // public IEnumerable<Presupuesto> Get()
    // {
    //     List<Producto> productos = new List<Producto>();
    //     var cadena = "Data Source = db/Tienda.db";
    //     using( var sqlitecon = new SqliteConnection(cadena)){
    //     // Importante crear y destruir!
    //     sqlitecon.Open();
    //     var consulta = @"SELECT * FROM Productos;";
    //     SqliteCommand comand = new SqliteCommand(consulta, sqlitecon);
    //     var reader = comand.ExecuteReader();
    //     while(reader.Read())
    //     {
    //         var Id = Convert.ToInt32(reader["idProducto"]);
    //         var Nombre = reader["Descripcion"].ToString();
    //         var Precio = Convert.ToInt32(reader["Precio"]);
    //         var producto = new Producto(Id, Nombre, Precio);
    //         productos.Add(producto);
    //     }
    //     sqlitecon.Close(); //Me aseguro que la BD queda liberada
    //     }
    //     return productos;
    // }
}
