using EasyMarket.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories
{
  public   class Repository<T> : IRepository<T> where T : class
  {

    private readonly EasyMarketContext _context;
    public Repository(EasyMarketContext context)
    {
      _context = context;
    }



    //public static User Get(string Username, string password)
    //{
    //  using (EasyMarketContext _context = new())
    //  {

    //  }

    //  var users = new List<User>();
    //  {
    //    new() { Id = 1, UserName = "erick", Password = "erick", Role = new Roles { RolesId = 1, Descricao = "Administrador" } },
    //        new() { Id = 1, UserName = "test", Password = "teste", Role = new Roles { RolesId = 2, Descricao = "Operacional" } }
    //    };

    //  users = _context.User.Where(x => x.UserName.Contains(Username)).ToList();

    //  return users
    //  .FirstOrDefault(x => x.UserName.ToLower() == Username.ToLower() && x.Password.ToLower() == password.ToLower());
    //}

    public bool Add(T entity)
    {
      return _context.Set<T>().AddRangeAsync(entity).IsCompleted;
    }

    public void Delete(T entity)
    {
      _context.Set<T>().Remove(entity);
    }

    public IEnumerable<T> Get( )
    {
      return _context.Set<T>().AsEnumerable<T>();

    }

    public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
      return _context.Set<T>().Where(predicate).AsEnumerable<T>();
    }

    public T GetById(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
      return _context.Set<T>().SingleOrDefault(predicate);
    }

  

    public async Task<T> Update(T entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      return _context.Set<T>().Update(entity).Entity;
    }

    
  }
}
