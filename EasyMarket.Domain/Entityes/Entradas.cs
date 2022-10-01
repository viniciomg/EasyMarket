using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Entityes
{
 public class Entradas
  {
    public int? Id { get; set; }
    [ForeignKey("Fornecedor")]
    public int fornecedorId { get; set; }
    public DateTime DataNota { get; set; }
    public DateTime DataCadastro { get; set; }
    public float  NumeroNota { get; set; }
    public float ValorTotal { get; set; }
    public string ChaveDeAcesso { get; set; }
    public ICollection<EntradaItems> items { get; set; }

    public Entradas()
    {

    }

    public Entradas( DateTime dataNota, DateTime dataCadastro, float numeroNota)
    {
      DataNota = dataNota;
      DataCadastro = dataCadastro;
      NumeroNota = numeroNota;

    }

  }
}
