using EasyMarket.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Dto.Dto_s.Entradas
{
 public  class EntradaItemsRequestDto
  {
    public int ProdutoId { get; set; }
    public float PrecoVenda { get; set; }
    public float PrecoCompra { get; set; }
    public int quantidade { get; set; }
    
  }
}
