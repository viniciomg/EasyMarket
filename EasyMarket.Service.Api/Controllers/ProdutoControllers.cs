using AutoMapper;
using EasyMarket.Application.Services.ProdutoService;
using EasyMarket.Domain.Dto.Produtos;
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
  public class ProdutoControllers : BaseController
  {
    private readonly IProdutoService _service;
    private readonly IHttpContextAccessor _httpContextAccessor;
    IMapper _mapper;
    public ProdutoControllers(IUnitOfWork unitOfWork, IProdutoService service, IMapper mapper) : base(unitOfWork)
    {
      _service = service;
      _mapper = mapper;
    }
    [Authorize]
    [HttpGet]
    [Route("getProdutos")]
    public async Task<IActionResult> getAllProdutos()
    {
      try
      {
        var retorno = await _service.GetProdutoAll();


        if (retorno == null)
          return NotFound("Não foi encontrado nenhum prdouto");

        var items = new
        {
          items = retorno,
          hasNext = true
        };

        return Ok(items);
      }
      catch (Exception ex)
      {
        return BadRequest("Houve uma falha ao tentar buscar os Produtos" + ex.Message);
      }

    }

    [Authorize]
    [HttpPost]
    [Route("GetProdutosIdOuDescricao")]
    public async Task<IActionResult> GetProdutosBarrasOuDescricao(ProdutosPesquisaRequestDto request)
    {
   

      try
      {
        if (request.codigo == null && string.IsNullOrEmpty(request.descricao)) BadRequest("Parâmetros inválidos");
        IEnumerable<Produtos> produtos = new List<Produtos>();
        if (request.codigo != 0)
        {
          var resposta  = await _service.GetProdutoAll();
          produtos = resposta.Where(x => x.Id == request.codigo).ToList();
          
          

        }
        else if (!string.IsNullOrEmpty(request.descricao))
        {
          var resposta = await _service.GetProdutoAll();
          produtos =  resposta.Where(x => x.descricao.ToUpper().Contains(request.descricao.ToUpper())).ToList();
        }

        var retorno = new
        {
          items = produtos,
          hasNext = true
        };
        return Ok(retorno);
      }
      catch(Exception ex)
      {
        return BadRequest("falha");
      }

   
    }

    [Authorize]
    [HttpPost]
    [Route("creteProduto")]
    public async Task<ActionResult<dynamic>> CreatEProdutoAsync([FromBody] Produtos model)
    {
      if (model == null)
        return BadRequest("dados invalidos");
      model.dataCadastro = DateTime.Now;
      var retorno = await _service.CreateProdutoAsync(model);
      if (retorno.Id != null && retorno.Id == 0)
        return NotFound("Ocorreu algum erro durante o processo!");
      return new
      {
        idRegister = retorno.Id,
        retorno = "Cadastro de produto realizado com sucesso!"

      };

    }
    [Authorize]
    [HttpPut]
    [Route("updateProduto")]
    public async Task<ActionResult<dynamic>> UpdateProdutoAsync([FromBody] Produtos model)
    {
      var retorno = _service.UpdateProdutoAsync(model);

      if (retorno.Exception != null)
      {
        return BadRequest("Ouve um erro ou mais ao relaizar o processo" + retorno.Exception.Message);
      }
      return new
      {
        idRegister = retorno.Id,
        retorno = "Cadastro de produto alterado com sucesso!"

      };
    }
    [Authorize]
    [HttpPost]
    [Route("excluirProduto")]
    public async Task<ActionResult<dynamic>> ExcluirProduto([FromBody] Produtos model)
    {
      if (model.Id == 0) BadRequest("Dados invalidos");
      var retorno = _service.ExlcuirProduto(model);
      if (retorno.Exception != null) BadRequest("Ouve uma mais erros" + retorno.Exception.InnerException.Message);

      return new
      {

        idRegister = retorno.Id,
        retorno = "Cadastro excluído com sucesso!"
      };
      
    }
  }

}

