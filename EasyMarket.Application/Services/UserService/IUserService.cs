using EasyMarket.Domain.Dto.Dto_s.User;
using EasyMarket.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Application.Services
{
  public interface IUserService
  {
    Task<Users> AutenticarUser(string login, string senha);

    Task<Users> UpdateUser(Users model);
    bool CreateUserSync(Users model);

    Task<ICollection<Users>> GetUserAll();

    Task<Users> GetUserById(Guid Id);

    Roles GetRolesById(int id);
  }
}
