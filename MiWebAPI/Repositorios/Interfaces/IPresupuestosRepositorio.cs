using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiWebAPI.Models;

namespace MiWebAPI.Repositorios{
  public interface IPresupuestosRepositorio
  {
    public void Crear(Presupuesto presupuesto);
    // public List<Presupuesto> ObtenerTodos();
    // public Presupuesto ObtenerPresupuestoPorId(int id);
    // public void Actualizar(int id, string nuevoNombre);
    // public bool Eliminar(int id);
  }
}