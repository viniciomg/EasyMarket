using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Entityes
{
public   class Produtos
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string  descricao { get; set; }
    public float precoVenda { get; set; }
    public int  estoque { get; set; }
    public bool status { get; set; }
    public string? Fabricante { get; set; }
    public ICollection<EntradaItems> entradaItens { get; set; }
    

    public DateTime? dataCadastro { get; set; }
    

  }
}
