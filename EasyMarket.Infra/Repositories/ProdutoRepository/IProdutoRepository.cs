using EasyMarket.Domain.Entityes;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories.ProdutoRepository
{
  public interface IProdutoRepository:IRepository<Produtos>
  {
    Task<Produtos> AddAsync (Produtos entity);

    Task<Produtos> RemovePrduto(Produtos entity);
  }
}
