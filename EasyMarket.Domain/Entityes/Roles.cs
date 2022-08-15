using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Entityes
{
 public class Roles
  {
    public int RolesId { get; set; }
    public string Descricao { get; set; }
    public ICollection<Users> Users { get; set; }


  }
}
