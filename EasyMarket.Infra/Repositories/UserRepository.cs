using EasyMarket.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories
{
    public static class UserRepository
    {


        public static User Get(string Username, string password)
        {
            var users = new List<User>{
            new() { Id = 1, UserName = "erick", Password = "erick", Role = "Manager" },
            new() { Id = 1, UserName = "test", Password = "teste", Role = "employee" }
        };
            
            return users
            .FirstOrDefault(x => x.UserName.ToLower() == Username.ToLower() && x.Password.ToLower() == password.ToLower());
        }

    }
}
