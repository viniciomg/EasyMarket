using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Dto.Dto_s.User
{
   public  class UserDtoRequest
    {
    public string login { get; set; }
    public string password { get; set; }
    public string remeberUser { get; set; }
   
  }
}
