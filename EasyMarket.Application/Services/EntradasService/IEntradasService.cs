using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Repositories.EntradasRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Application.Services.EntradasService
{

  public interface IEntradasService
  {
    Task<Entradas> InsertEntradas(Entradas model);
    Task<ICollection<Entradas>> getAllEntradas();

    Task<EntradaItems> insertEntradaItems(EntradaItems model);
  }
}
