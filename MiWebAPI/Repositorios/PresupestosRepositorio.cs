using MiWebAPI.Models;
using Microsoft.Data.Sqlite;

namespace MiWebAPI.Repositorios{
  public class PresupuestosRepositorio : IPresupuestosRepositorio
  {
    private string _cadenaDeConexion;
    public PresupuestosRepositorio(string cadenaDeConexion)
    {
        _cadenaDeConexion = cadenaDeConexion;
    }

    public void Crear(Presupuesto presupuesto)
    {
        var NombreDestinatario = Convert.ToString(presupuesto.NombreDestinatario);
        var FechaCreacion = Convert.ToDateTime(presupuesto.FechaCreacion);

        using (var sqlitecon = new SqliteConnection(_cadenaDeConexion))
        {
            sqlitecon.Open();
            var consulta = @"INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) 
                            VALUES (@NombreDestinatario, @FechaCreacion);";

            using (var comand = new SqliteCommand(consulta, sqlitecon))
            {
                comand.Parameters.AddWithValue("@NombreDestinatario", NombreDestinatario);
                comand.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);

                comand.ExecuteNonQuery();
            }
        }
    }


    public List<Presupuesto> ObtenerTodos()
    {
        var presupuestos = new List<Presupuesto>(); 
        var consulta = @"SELECT * FROM Presupuestos";
        using( var sqlitecon = new SqliteConnection(_cadenaDeConexion)){
            sqlitecon.Open();      
            SqliteCommand command = new SqliteCommand(consulta, sqlitecon);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader["idPresupuesto"]);
                    var NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]);
                    var FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    var presupuesto = new Presupuesto(id, NombreDestinatario, FechaCreacion);
                    presupuestos.Add(presupuesto);
                }   
            }
            sqlitecon.Close();
        }
        return presupuestos;
    }


    public Presupuesto ObtenerPresupuestoPorId(int id)
    {
        Presupuesto presupuesto = null;
        var consulta = @"SELECT * FROM Presupuestos WHERE idPresupuesto = @id";
        using (var sqlitecon = new SqliteConnection(_cadenaDeConexion))
        {
            sqlitecon.Open();
            SqliteCommand command = new SqliteCommand(consulta, sqlitecon);
            command.Parameters.AddWithValue("@id", id);
            using(var reader = command.ExecuteReader()){
                if (reader.Read())
                {
                    var idPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    var NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]);
                    var FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    presupuesto = new Presupuesto(idPresupuesto, NombreDestinatario, FechaCreacion);
                }
            }
            sqlitecon.Close();
        }
        return presupuesto;
    }

    public Presupuesto ObtenerPresupuestoCompletoPorId(int id)
    {
        Presupuesto presupuesto = null;
        var consulta = @"SELECT Pres.idPresupuesto, Pres.NombreDestinatario, Pres.FechaCreacion, Prod.idProducto, Prod.Descripcion AS Producto, Prod.Precio,PresD.Cantidad
                        FROM Presupuestos Pres
                        INNER JOIN  PresupuestosDetalle PresD ON Pres.idPresupuesto = PresD.idPresupuesto
                        INNER JOIN Productos Prod ON Prod.idProducto = PresD.idProducto
                        WHERE Pres.idPresupuesto = @id;";
        using (var sqlitecon = new SqliteConnection(_cadenaDeConexion))
        {
            sqlitecon.Open();
            SqliteCommand command = new SqliteCommand(consulta, sqlitecon);
            command.Parameters.AddWithValue("@id", id);
            using(var reader = command.ExecuteReader()){
                if (reader.Read())
                {
                    var idPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    var NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]);
                    var FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    var presupuestoCompleto = new Presupuesto(idPresupuesto, NombreDestinatario, FechaCreacion);
                }
            }
            sqlitecon.Close();
        }
        return presupuesto;
    }




    public bool Actualizar(int idPresupuesto, Producto producto, int cantidad)
    {
        bool resultado = false;
        if (idPresupuesto <= 0)
            return resultado;

        var idProducto = producto.IdProducto;
        const string query = "UPDATE PresupuestosDetalle SET Cantidad = @cantidad WHERE idPresupuesto = @idPresupuesto AND idProducto = @idProducto;";
        using (var sqliteConnection = new SqliteConnection(_cadenaDeConexion))
        {
            sqliteConnection.Open();
            using (var command = new SqliteCommand(query, sqliteConnection))
            {
                command.Parameters.AddWithValue("@idPresupuesto", idPresupuesto);
                command.Parameters.AddWithValue("@idProducto", idProducto);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected != 0)
                    resultado = true;
            }
            sqliteConnection.Close();
        }
        return resultado;
    }

    public bool Eliminar(int id)
    {
        int rowsAffected;
        const string query = "DELETE FROM Presupuestos WHERE idPresupuesto = @id";
        using (var sqliteConnection = new SqliteConnection(_cadenaDeConexion))
        {
            sqliteConnection.Open();
            using (var command = new SqliteCommand(query, sqliteConnection))
            {
                command.Parameters.AddWithValue("@id", id);
                rowsAffected = command.ExecuteNonQuery();
                sqliteConnection.Close();
            }
            sqliteConnection.Close();
        }
        return rowsAffected==1;
    }
  }
}