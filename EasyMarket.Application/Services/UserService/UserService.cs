using EasyMarket.Application.Services.UserService;
using EasyMarket.Domain.Dto.Dto_s.User;
using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace EasyMarket.Application.Services.UserService
{


 public class UserService : IUserService
  {
    private readonly IUserRepository _userrepository;

    public UserService(IUserRepository userrepository)
    {
      _userrepository = userrepository;
    }

    public async Task<Users> AutenticarUser(string login, string senha )
    { 
        var user=  _userrepository.Get();
      
      return user.FirstOrDefault(x => x.email.ToLower() == login.ToLower() && x.Password.ToLower() == senha.ToLower());
    }

    public bool CreateUserSync(Users model)
    {

      return _userrepository.Add(model);

    }

    public Roles GetRolesById(int id)
    {
      return _userrepository.GetRolesById(id);
    }

    public async Task<ICollection<Users>> GetUserAll()
    {
      var user = _userrepository.Get();
      return user.OrderBy(user => user.nome).ToList();
    }

    public async Task<Users> GetUserById(Guid Id)
    {

      Expression<Func<Users, bool>> funcao = a => a.Id == Id;

      var user =  _userrepository.GetById(funcao);
      
      return user;
    }

    public async Task<Users> UpdateUser(Users model)
    {
      return await _userrepository.Update(model);
    }

  }
}
