using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiWebAPI.Models;
using Microsoft.Data.Sqlite;

namespace MiWebAPI.Repositorios{
  public class PresupuestosRepositorio : IPresupuestosRepositorio
  {
    public void Crear(Presupuesto presupuesto){

      var id = presupuesto.IdPresupuesto;
      var NombreDestinatario = presupuesto.NombreDestinatario;
      var FechaCreacion = presupuesto.FechaCreacion;

      var cadena = "Data Source = db/Tienda.db";
      using( var sqlitecon = new SqliteConnection(cadena)){
        sqlitecon.Open();
        var consulta = @"INSERT INTO Presupuesto (NombreDestinatario, FechaCreacion) VALUES (@NombreDestinatario, @FechaCreacion);";
        SqliteCommand comand = new SqliteCommand(consulta, sqlitecon);
        comand.Parameters.AddWithValue("@NombreDestinatario", NombreDestinatario);
        comand.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
        comand.ExecuteNonQuery();
        sqlitecon.Close();
      }
    }


    public List<Presupuesto> ObtenerTodos(){

      List<Presupuesto> presupuestos = new List<Presupuesto>(); 
      var cadena = "Data Source = db/Tienda.db";
      using( var sqlitecon = new SqliteConnection(cadena)){
        sqlitecon.Open();      
        var consulta = @"SELECT * FROM Presupuestos";
        SqliteCommand command = new SqliteCommand(consulta, sqlitecon);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
          var id = Convert.ToInt32(reader["idPresupuesto"]);
          var NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]);
          var FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
          Presupuesto presupuesto = new Presupuesto(id, NombreDestinatario, FechaCreacion);
          presupuestos.Add(presupuesto);
        }
        sqlitecon.Close();
      }
      return presupuestos;
    }




    public Presupuesto ObtenerPresupuestoPorId(int id)
    {
      int idPresupuesto = 0;
      string NombreDestinatario = "Sin destinatario";
      DateTime FechaCreacion = DateTime.MinValue;

      var cadena = "Data Source = db/Tienda.db";
      using (var sqlitecon = new SqliteConnection(cadena))
      {
          sqlitecon.Open();
          var consulta = @"SELECT * FROM Presupuestos WHERE idPresupuesto = @id";
          SqliteCommand command = new SqliteCommand(consulta, sqlitecon);
          command.Parameters.AddWithValue("@id", id);
          var reader = command.ExecuteReader();

          if (reader.Read())
          {
              idPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
              NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]);
              FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
          }

          sqlitecon.Close();
      }
      return new Presupuesto(idPresupuesto, NombreDestinatario, FechaCreacion);
    }

    public void Actualizar(int id, Producto produco, int cantidad){

    }
    public bool Eliminar(int id)
    {
        int rowsAffected;
        var connectionString = "Data Source=db/Tienda.db";
        using (var sqliteConnection = new SqliteConnection(connectionString))
        {
            const string query = "DELETE FROM Presupuestos WHERE idPresupuesto = @id";
            using (var command = new SqliteCommand(query, sqliteConnection))
            {
                sqliteConnection.Open();
                command.Parameters.AddWithValue("@id", id);
                rowsAffected = command.ExecuteNonQuery();
                sqliteConnection.Close();
                return rowsAffected==1;
            }
        }
    }
  }
}