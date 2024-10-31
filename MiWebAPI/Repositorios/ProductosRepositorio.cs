using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiWebAPI.Models;
using Microsoft.Data.Sqlite;

namespace MiWebAPI.Repositorios
{
  public class ProductosRepositorio : IProductosRepositorio
  {
      public void Create(Producto producto){
        var cadena = "Data Source = db/Tienda.db";
        using( var sqlitecon = new SqliteConnection(cadena)){
          // Importante crear y destruir!
          sqlitecon.Open();
          var consulta = @"INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio);";
          SqliteCommand comand = new SqliteCommand(consulta, sqlitecon);
          // Agregar parámetros para evitar inyecciones SQL
          comand.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
          comand.Parameters.AddWithValue("@Precio", producto.Precio);
          // Ejecutar el comando
          comand.ExecuteNonQuery();
          sqlitecon.Close(); //Me aseguro que la BD queda liberada
        }
    }
    public List<Producto> GetAll()
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
    public Producto GetById(int id)
    {
      var Id = -999;
      var Nombre = "";
      var Precio = 0;
      var cadena = "Data Source = db/Tienda.db";
      using( var sqlitecon = new SqliteConnection(cadena)){
      // Importante crear y destruir!
      sqlitecon.Open();
      var consulta = @$"SELECT * FROM Productos WHERE idProducto is {id};";
      SqliteCommand comand = new SqliteCommand(consulta, sqlitecon);
      var reader = comand.ExecuteReader();
      if(reader.Read()){
          Id = Convert.ToInt32(reader["idProducto"]);
          Nombre = reader["Descripcion"].ToString();
          Precio = Convert.ToInt32(reader["Precio"]);
      } 
      var producto = new Producto(Nombre, Precio);
      sqlitecon.Close(); //Me aseguro que la BD queda liberada
      return (producto);
      }
    }
    public void Remove(int id)
    {

    }
    public void Update(Producto director)
    {

    }
  } 
}