using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Domain.Dto.Dto_s.User
{
   public  class UserDto
    {
        public int id { get; set; }
        public string UsarName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
