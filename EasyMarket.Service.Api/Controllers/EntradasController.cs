using AutoMapper;
using EasyMarket.Application.Services.EntradasService;
using EasyMarket.Domain.Dto.Dto_s.Entradas;
using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Repositories;
using EasyMarket.Service.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMarket.Service.Api.Controllers
{
  [Route("v1")]
  [ApiController]
  public class EntradasController : BaseController
  {
    private readonly IEntradasService _service;
    IMapper _mapper;
    public EntradasController(IUnitOfWork unitOfWork, IEntradasService service, IMapper mapper) : base(unitOfWork)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    [Route("InsertEntradas")]
    public async Task<ActionResult<dynamic>> inserirEntradas([FromBody] EntradasRequestDto entradasDto)
    {
      if (entradasDto == null) BadRequest("Falha ao inserir entradas. Objeto nulo!");
      entradasDto.DataCadastro = DateTime.Now;
      int idRetorno= 0;
      try
      {
        var Entradas = new Entradas();
        var mapEntradas = _mapper.Map(entradasDto, Entradas);
        var retornoEntradas = await _service.InsertEntradas(mapEntradas);
        idRetorno = (int)retornoEntradas.Id;
        return new
        {
          idRegister = idRetorno,
          retorno = "Entrada concluída com sucesso!"
        };
      }
      catch(Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Authorize]
    [Route("buscarEntradas")]
    public async Task<IActionResult> getAllEntradas()
    {
      var retorno = _service.getAllEntradas();
      var entradasSerialize = new JsonResult(retorno);

      if (retorno.Exception!= null) return BadRequest(retorno.Exception.InnerException);

      var items = new
      {
        items = retorno.Result,
        hasNext = true
      };
      return Ok(items);

    }
  }
}
