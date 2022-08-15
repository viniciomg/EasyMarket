using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories
{
  public interface IRepository<T> where T: class 
  {
    IEnumerable<T> Get();
    IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    T GetById(Expression<Func<T, bool>> predicate);
    bool Add(T entity);
    void Delete(T entity);
    Task<T> Update(T entity);
  
  }
}
