using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Repositories.ProdutoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Application.Services.ProdutoService
{

  public class ProdutoService : IProdutoService
  {
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository userrepository)
    {
      _produtoRepository = userrepository;
    }
    public async Task<Produtos> CreateProdutoAsync(Produtos model)
    {
      return await _produtoRepository.AddAsync(model);
    }

    public Task<Produtos> ExlcuirProduto(Produtos model)
    {
     return _produtoRepository.RemovePrduto(model);
    }

    public async Task<IEnumerable<Produtos>> GetProdutoAll()
    {
      return _produtoRepository.Get();
    }

    public async Task<Produtos> UpdateProdutoAsync(Produtos model)
    {
      return await _produtoRepository.Update(model);
    }

    
  }
}
