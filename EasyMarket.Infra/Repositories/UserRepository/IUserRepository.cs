using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMarket.Domain.Entityes;

namespace EasyMarket.Infra.Repositories.User
{

  public interface IUserRepository :IRepository<Users>
  {
    IEnumerable<Users> GetUserByName();

    Roles GetRolesById(int id);
  }
}
