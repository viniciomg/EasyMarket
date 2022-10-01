using AutoMapper;
using EasyMarket.Application.AutoMapper;
using EasyMarket.Application.Services;
using EasyMarket.Application.Services.EntradasService;
using EasyMarket.Application.Services.EntradasService.EntradaItemsService;
using EasyMarket.Application.Services.ProdutoService;
using EasyMarket.Application.Services.UserService;
using EasyMarket.Domain.Dto.Dto_s.Entradas;
using EasyMarket.Domain.Dto.Dto_s.User;
using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Context;
using EasyMarket.Infra.Repositories;
using EasyMarket.Infra.Repositories.EntradasRepository;
using EasyMarket.Infra.Repositories.EntradasRepository.EntradaItemsRepository;
using EasyMarket.Infra.Repositories.ProdutoRepository;
using EasyMarket.Infra.Repositories.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace EasyMarket.Service.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {


      services.AddCors();
      services.AddControllers().AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
      });

      services.AddDbContext<EasyMarketContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
      services.AddDatabaseDeveloperPageExceptionFilter();

      services.AddTransient<IUnitOfWork, UnitOfWork>();

      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IUserRepository, UserRepository>();

      services.AddScoped<IProdutoService, ProdutoService>();
      services.AddScoped<IProdutoRepository, ProdutoRepository>();

      services.AddScoped<IEntradasRepository, EntradasRepository>();
      services.AddScoped<IEntradasService, EntradasService>();

      services.AddScoped<IEntradaItemsRepository, EntradaItemsRepository>();
      services.AddScoped<IEntradaItemsService, EntradaItemsService>();

      var key = Encoding.ASCII.GetBytes(settings.Seceet);
      services.AddAuthentication(

          x =>
          {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          }
          ).AddJwtBearer(x =>
          {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = new SymmetricSecurityKey(key),
              ValidateIssuer = false,
              ValidateAudience = false

            };

          });

      var configuration = new MapperConfiguration(cfg =>
      {
        cfg.AllowNullCollections = true;
        cfg.CreateMap<CreateUserRequest, Users>();
        cfg.CreateMap<Users, CreateUserRequest>();
        cfg.CreateMap<Users, UserDtoResponse>();
        cfg.CreateMap<UserDtoResponse, Users>();
        cfg.CreateMap<EntradasRequestDto, Entradas>();
        cfg.CreateMap<EntradaItemsRequestDto, EntradaItems>();
      });

      IMapper mapper = configuration.CreateMapper();
      services.AddSingleton(mapper);



      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyMarket.Service.Api", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer",
          BearerFormat = "JWT",
          In = ParameterLocation.Header,
          Description = "JWT Authorization header using the Bearer scheme.\r\n\r\n Enter 'Bearer'[space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyMarket.Service.Api v1"));
      }
      app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
      app.UseHttpsRedirection();

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
