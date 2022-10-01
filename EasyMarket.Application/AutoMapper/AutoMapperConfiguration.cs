using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMarket.Application.AutoMapper;
using AutoMapper;
using EasyMarket.Domain.Entityes;
using EasyMarket.Domain.Dto.Dto_s.User;
using EasyMarket.Domain.Dto.Dto_s.Entradas;

namespace EasyMarket.Application.AutoMapper
{
  public static class AutoMapperConfiguration
  {
    public static void AutoMapperConfigurations(this IServiceCollection services)
    {
      
      var configuration = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<CreateUserRequest, Users>();
        cfg.CreateMap<Users, CreateUserRequest>();
        cfg.CreateMap<EntradasRequestDTO, Entradas>();
        cfg.CreateMap<EntradaItemsRequestDto, EntradaItems>();
        
      });

      IMapper mapper = configuration.CreateMapper();
      services.AddSingleton(mapper);


    }

  }

  internal class EntradasRequestDTO
  {
  }
}
