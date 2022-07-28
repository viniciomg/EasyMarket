using EasyMarket.Domain.Dto.Dto_s.User;
using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Repositories;
using EasyMarket.Service.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMarket.Service.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController :ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync( [FromBody] User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);
            
                
            
            if (user == null)
                return NotFound(new { message = "usuario ou senha invalidos" });

            var token = TokenServices.GenerateToken(user);
           
            return new
            {
                user = user,
                token = token
            };

        }

    }
}
