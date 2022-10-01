using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Entityes
{
 public class Fornecedor
  {

    public int Id { get; set; }
    public string razaoSocial { get; set; }

    public string nomeFantasia { get; set; }
    
  }
}
