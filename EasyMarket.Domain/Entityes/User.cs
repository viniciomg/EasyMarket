using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Entityes
{
   public class Users
    {
    public virtual Guid Id { get; set; }
    public string username { get; set; }
    public string nome  { get; set; }
    public DateTime datanascimento { get; set; }
    public string cpf { get; set; }
    public string email { get; set; }
    public string estado { get; set; }
    public string Genero { get; set; }
    public int number { get; set; }
    
    public string endereco { get; set; }
    public string Password { get; set; }
    public string cidade { get; set; }
    public int RolesId { get; set; }
    public  Roles Roles { get; set; }


    public Users()
    {
      Id = new Guid();
    }

  }
}
