using EasyMarket.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories.EntradasRepository.EntradaItemsRepository
{
  public interface IEntradaItemsRepository : IRepository<EntradaItems>
  {
    Task<EntradaItems> InserirEntradaItensAsync(EntradaItems model);
  }
}
