using EasyMarket.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Dto.Dto_s.Entradas
{
  public class EntradasRequestDto
  {

    public int fornecedorId { get; set; }
    public DateTime DataNota { get; set; }
    public DateTime DataCadastro { get; set; }
    public float NumeroNota { get; set; }
    public float ValorTotal { get; set; }
    public string ChaveDeAcesso { get; set; }
    public ICollection<EntradaItemsRequestDto> items { get; set; }

  }
}
