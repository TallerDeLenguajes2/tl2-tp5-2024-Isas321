using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using EspacioTienda;
using System.Net;
namespace MiWebAPI.Controllers;


[ApiController]
[Route("[controller]")]

public class PresupuestosController : ControllerBase
{
      [HttpGet("GetPresupuestos", Name = "GetPresupuestos")]
    public IEnumerable<Presupuesto> GetPresupuestos()
    {
        List<Presupuesto> presupuestos = new List<Presupuesto>();
        var cadena = "Data Source = db/Tienda.db";
        try
        {
            using (var sqlitecon = new SqliteConnection(cadena))
            {
                sqlitecon.Open();
                var consulta = @"SELECT * FROM Presupuestos;";
                SqliteCommand comand = new SqliteCommand(consulta, sqlitecon);
                var reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    var Id = Convert.ToInt32(reader["idPresupuesto"]);
                    var NombreDestinatario = reader["NombreDestinatario"].ToString();
                    var FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    var presupuesto = new Presupuesto(Id, NombreDestinatario, FechaCreacion);
                    presupuestos.Add(presupuesto);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener presupuestos: " + ex.Message);
        }
    return presupuestos;
    }
}