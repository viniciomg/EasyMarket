using EasyMarket.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories.EntradasRepository
{
  public interface IEntradasRepository : IRepository<Entradas>
  {
    Task<Entradas> insertAsyncEntradas(Entradas model);

    Task<ICollection<Entradas>> getAllEntradas();
  }
}
