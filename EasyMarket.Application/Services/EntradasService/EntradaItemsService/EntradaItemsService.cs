using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Repositories.EntradasRepository;
using EasyMarket.Infra.Repositories.EntradasRepository.EntradaItemsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Application.Services.EntradasService.EntradaItemsService
{
  public class EntradaItemsService : IEntradaItemsService
  {
    private readonly IEntradaItemsRepository _entradasRepository;
    public EntradaItemsService(IEntradaItemsRepository entradasRepository)
    {
      _entradasRepository = entradasRepository;
    }
    public async Task<EntradaItems> InsertEntradaItem(EntradaItems model)
    {
     return  await _entradasRepository.InserirEntradaItensAsync(model);
      
    }
  }
}
