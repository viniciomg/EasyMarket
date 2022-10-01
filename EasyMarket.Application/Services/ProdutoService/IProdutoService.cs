using EasyMarket.Domain.Entityes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMarket.Application.Services.ProdutoService
{
  public interface IProdutoService
  {
    Task<IEnumerable<Produtos>> GetProdutoAll();
    Task<Produtos> CreateProdutoAsync(Produtos model);

    Task<Produtos> UpdateProdutoAsync(Produtos model);

    Task<Produtos> ExlcuirProduto(Produtos model);

    
  }
}
