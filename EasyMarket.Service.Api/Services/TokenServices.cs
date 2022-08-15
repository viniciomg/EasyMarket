using EasyMarket.Domain.Entityes;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Service.Api.Services
{
    public static  class TokenServices
    {
        public static string GenerateToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.Seceet);
            var tokenDesciptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.nome),  //user.Identity.Name --classe da asp net pode ser chamado da controller
                    new Claim(ClaimTypes.Role, user.Roles.Descricao)  // user.IsInRole --claase do .net pode ser chamado em outros lugares.
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =  new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDesciptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
