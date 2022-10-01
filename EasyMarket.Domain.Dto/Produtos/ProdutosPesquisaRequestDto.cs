using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Dto.Produtos
{
public  class ProdutosPesquisaRequestDto
  {
    public int codigo { get; set; }
    public string descricao { get; set; }
  }
}
