using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Entityes
{
  public class EntradaItems
  {
    public int Id { get; set; }
    public int EntradasId { get; set; }
    public Entradas entradas { get; set; }
    public int ProdutoId { get; set; }
    public Produtos produtos { get; set; }
    public float PrecoCompra { get; set; }
    public int quantidade { get; set; }
  }
}
