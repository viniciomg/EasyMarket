using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Dto.Dto_s.User
{
  public class CreateUserRequest
  {

    public string? Id { get; set; }
    public string nome { get; set; }
    public string genero { get; set; }
    public DateTime? dataNascimento { get; set; }
    public string cpf { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string telefone { get; set; }
    public string endereco { get; set; }
    public string number { get; set; }

    public string estado { get; set; }
    public string cidade { get; set; }

    public string permissao { get; set; }

  }
}
