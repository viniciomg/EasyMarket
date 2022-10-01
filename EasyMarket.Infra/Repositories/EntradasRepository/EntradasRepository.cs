using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories.EntradasRepository
{
  public class EntradasRepository : IEntradasRepository
  {
    private readonly EasyMarketContext _context;

    public EntradasRepository(EasyMarketContext context)
    {
      _context = context;
    }

    public bool Add(Entradas entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(Entradas entity)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Entradas> Get()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Entradas> Get(Expression<Func<Entradas, bool>> predicate)
    {
      throw new NotImplementedException();
    }

    public  async Task<ICollection<Entradas>> getAllEntradas()
    {
      var retorno = _context.Entradas.Include(e=> e.items).ToList();
      /*for(int i =0; i <  retorno.Count; i++)
      {
        retorno[i].produtos.entradas.Clear();
      }*/
      
      return retorno;
    }

    public Entradas GetById(Expression<Func<Entradas, bool>> predicate)
    {
      throw new NotImplementedException();
    }

    public async  Task<Entradas> insertAsyncEntradas(Entradas model)
    {
      var teste = _context.Entradas.Add(model);
      _context.SaveChanges();
      return teste.Entity;
    }

    public Task<Entradas> Update(Entradas entity)
    {
      throw new NotImplementedException();
    }
  }
}
