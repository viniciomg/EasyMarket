using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Repositories.EntradasRepository;
using EasyMarket.Infra.Repositories.EntradasRepository.EntradaItemsRepository;
using EasyMarket.Infra.Repositories.ProdutoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Application.Services.EntradasService
{
  public class EntradasService : IEntradasService
  {
    private readonly IEntradasRepository _entradasRepository;
    private readonly IEntradaItemsRepository _itemsRepository;
    private readonly IProdutoRepository _produtoRepository;
    

      public EntradasService(IEntradasRepository entradasRepository, IEntradaItemsRepository itemsRepository, IProdutoRepository produtoRepository)
    {
      _entradasRepository = entradasRepository;
      _itemsRepository = itemsRepository;
        _produtoRepository = produtoRepository;


    }
    public async  Task<Entradas> InsertEntradas(Entradas model)
    {
      var retorno = await _entradasRepository.insertAsyncEntradas(model);
      
      if(retorno != null)
      {
          foreach(var item in model.items){
          var prod = new Produtos
          {
            Id = item.ProdutoId,
            estoque = item.quantidade
          };
          var retornoUpdateProd =await _produtoRepository.Update(prod);
          if (retornoUpdateProd == null) return null;

        }
       
      }
      return retorno;
    }

    public async Task<ICollection<Entradas>> getAllEntradas()
    {
      var retorno = await _entradasRepository.getAllEntradas();
      foreach(var item in retorno)
      {
        foreach (var items in item.items){
          items.entradas = null;
        }
      }
      return retorno;
    }

    public async  Task<EntradaItems> insertEntradaItems(EntradaItems model)
    {
      return await _itemsRepository.InserirEntradaItensAsync(model);
    }
  }
}
