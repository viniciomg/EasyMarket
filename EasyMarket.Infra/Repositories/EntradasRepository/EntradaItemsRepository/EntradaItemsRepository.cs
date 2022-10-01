using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories.EntradasRepository.EntradaItemsRepository
{
  public class EntradaItemsRepository : IEntradaItemsRepository
  {
    private readonly EasyMarketContext _context;

    public EntradaItemsRepository(EasyMarketContext context)
    {
      _context = context;
    }
    public bool Add(EntradaItems entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(EntradaItems entity)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<EntradaItems> Get()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<EntradaItems> Get(Expression<Func<EntradaItems, bool>> predicate)
    {
      throw new NotImplementedException();
    }

    public EntradaItems GetById(Expression<Func<EntradaItems, bool>> predicate)
    {
      throw new NotImplementedException();
    }

    public  async  Task<EntradaItems> InserirEntradaItensAsync(EntradaItems model)
    {
       var retorno =   _context.EntradaItems.Add(model);
      _context.SaveChanges();
      return retorno.Entity;
    }

    public Task<EntradaItems> Update(EntradaItems entity)
    {
      throw new NotImplementedException();
    }
  }
}
