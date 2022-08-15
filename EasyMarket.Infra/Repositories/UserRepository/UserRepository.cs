using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories.User
{

  public class UserRepository :  IUserRepository
  {
    EasyMarketContext _context;
    public UserRepository(EasyMarketContext context)
    {
      _context = context;
    }
    public bool Add(Users entity)
    {
       var teste=  _context.User.AddRangeAsync(entity);
      _context.SaveChanges();
      return teste.IsCompleted;
    }

    public void Delete(Users entity)
    {
      _context.User.Remove(entity);
    }

    public IEnumerable<Users> Get()
    {
      return _context.User.Include(e => e.Roles).ToList();
     
    }

    public IEnumerable<Users> Get(Expression<Func<Users, bool>> predicate)
    {
      
        return _context.User.Include(e => e.Roles).Where(predicate);
      
    }

    public Users GetById(Expression<Func<Users, bool>> predicate)
    {
      return _context.User.Include(e=>e.Roles).FirstOrDefault(predicate);
    }

    public Roles GetRolesById(int id)
    {
      return _context.Roles.FirstOrDefault(x => x.RolesId == id);
    }

    public IEnumerable<Users> GetUserByName()
    {
      return Get().OrderBy(c => c.nome).ToList();
    }
    public async Task<Users>  Update(Users entity)
    {
       var retorno=  _context.User.Update(entity);
      _context.SaveChanges();
      return retorno.Entity;
      
    }
 
  }
}
