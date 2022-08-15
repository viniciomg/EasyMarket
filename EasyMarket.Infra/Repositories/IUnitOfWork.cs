

using EasyMarket.Domain.Entityes;

namespace EasyMarket.Infra.Repositories
{
  public interface IUnitOfWork
  {
    IRepository<Users> UserRespository { get; }
    void Commit();
  }
}
