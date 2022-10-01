using AutoMapper;
using EasyMarket.Application.Services;
using EasyMarket.Application.Services.UserService;
using EasyMarket.Domain.Dto.Dto_s.User;
using EasyMarket.Domain.Entityes;

using EasyMarket.Infra.Repositories;
using EasyMarket.Infra.Repositories.User;
using EasyMarket.Service.Api.Controllers.Base;
using EasyMarket.Service.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMarket.Service.Api.Controllers
{
  [ApiController]
  [Route("v1")]
  public class LoginController : BaseController
  {
    private readonly IUserService _service;
    private readonly IHttpContextAccessor _httpContextAccessor;
    IMapper _mapper;
    public LoginController(IUnitOfWork unitOfWork, IUserService service, IMapper mapper) : base(unitOfWork)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserDtoRequest model)
    {
      if (model.login == null)
        return NotFound(new { message = "Login invalido" });
      try
      {
        var user = await _service.AutenticarUser(model.login, model.password);

        if (user == null)
          return NotFound(new { message = "usuario ou senha invalidos" });

        var token = TokenServices.GenerateToken(user);
        user.Password = "";
        return new
        {
          user = new { user.nome, user.username},
          token = token
        };
      }
      catch (Exception ex)
      {
       
        return BadRequest("Falha ao Autenticar");
      }

    }


    [Authorize]
    [HttpPost]
    [Route("CreateUser")]
    public async Task<ActionResult<dynamic>> CreateAsync([FromBody] CreateUserRequest model)
    {
      string mensagem = "";
      if (model == null)
        return BadRequest("Dados invalidos");

      var newUser = new Users();
      var user = _mapper.Map(model, newUser);
      user.RolesId = int.Parse(model.permissao);

      try
      {
       var  retorno = _service.CreateUserSync(user);
        if (retorno)
        {
          mensagem = "Cadastro Salvo com Sucesso";
        }
        else mensagem = "Houve uma falha";
        return new
        {
          idRegister = user.Id,
          retorno = mensagem
        };

      }catch(Exception ex)
      {
        throw new Exception("Falha ao cadastrar" + ex.Message);
      }
      //model.Id = new Guid();
      
    }
    //[Authorize]
    [HttpPut]
    [Route("updateUser")]
    public async Task<ActionResult<dynamic>> UpdateAsync([FromBody] CreateUserRequest model)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    {
      string mensagem = "";
      if (model == null || model.Id ==null)
        return BadRequest("Dados invalidos");
      var newUser = new Users();
      var user = _mapper.Map(model, newUser);
      user.Roles =  _service.GetRolesById(int.Parse(model.permissao));
      try
      {
        var retorno = await  _service.UpdateUser(user);
        if (retorno.Id == user.Id)
        {
          mensagem = "Cadastro alterado com Sucesso";
        }
        else mensagem = "Houve uma falha";
        return new
        {
          idRegister = user.Id,
          retorno = mensagem
        };

      }
      catch (Exception ex)
      {
        throw new Exception("Falha ao cadastrar" + ex.Message);
      }
      //model.Id = new Guid();
      
    }

    [Authorize]
    [HttpGet]
    [Route("getUsers")]
    public async Task<IActionResult> GerUsersAll()
    {

      var users = await _service.GetUserAll();
      var userMap = _mapper.Map(users ,new[] { new UserDtoResponse() });

      var items = new
      {
        items = userMap,
        hasNext = true
      };
      var userSereialize =new JsonResult(items);
      return Ok(userSereialize.Value);
    }

    //[Authorize]
    [HttpGet]
    [Route("getUsersById")]
    public async Task<IActionResult> GerUserById(Guid id)
    {

      var users = await _service.GetUserById(id);
     users.Roles.Users =null;
      var items = new
      {
        items = users,
        hasNext = true
      };
      var userSereialize = new JsonResult(items);
      return Ok(userSereialize.Value);
    }
  }
}
