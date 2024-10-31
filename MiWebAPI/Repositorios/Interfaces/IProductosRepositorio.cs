using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiWebAPI.Models;

namespace MiWebAPI.Repositorios
{
  public interface IProductosRepositorio
  {
    public void Create(Producto producto);
    public List<Producto> GetAll();
    public Producto GetById(int id);
    public void Remove(int id);
    public void Update(Producto director);

  }
}