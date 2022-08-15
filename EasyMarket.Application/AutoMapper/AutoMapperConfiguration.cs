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
      });

      IMapper mapper = configuration.CreateMapper();
      services.AddSingleton(mapper);


    }

  }
}
