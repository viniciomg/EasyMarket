using EasyMarket.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Application.Services.EntradasService.EntradaItemsService
{
 public  interface IEntradaItemsService
  {
    Task<EntradaItems> InsertEntradaItem(EntradaItems model);
  }
}
