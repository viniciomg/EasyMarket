using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    public EasyMarketContext _context;
    
    private Repository<Users> _userRepository;
    public UnitOfWork(EasyMarketContext context)
    {
      _context = context;
    }

    public IRepository<Users> UserRespository
    {
      get
      {
        return _userRepository = _userRepository ?? new Repository<Users>(_context);
      }
    } 

    public void Commit()
    {
      _context.SaveChanges();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
