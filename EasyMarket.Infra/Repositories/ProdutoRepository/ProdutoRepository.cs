using EasyMarket.Domain.Entityes;
using EasyMarket.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Repositories.ProdutoRepository
{
  public class ProdutoRepository : IProdutoRepository
  {
    EasyMarketContext _context;

    public ProdutoRepository(EasyMarketContext context)
    {
      _context = context;
    }

    public bool Add(Produtos entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Produtos> AddAsync(Produtos entity)
    {
      var teste = _context.Produtos.Add(entity);
      _context.SaveChanges();
      return teste.Entity;
    }

    public void Delete(Produtos entity)
    {
      _context.Produtos.Remove(entity);
    }

    public IEnumerable<Produtos> Get()
    {
      return _context.Produtos.ToList();
    }

    public IEnumerable<Produtos> Get(Expression<Func<Produtos, bool>> predicate)
    {
      return _context.Produtos.Where(predicate);
    }

    public Produtos GetById(Expression<Func<Produtos, bool>> predicate)
    {
      return _context.Produtos.FirstOrDefault(predicate);
    }

    public async Task<Produtos> RemovePrduto(Produtos entity)
    {
      var retorno= _context.Produtos.Remove(entity).Entity;
      _context.SaveChanges();
      return retorno;
    }

    public async Task<Produtos> Update(Produtos entity)
    {
      var retorno = _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);
      
      if (retorno == null) return null;
      if (entity.precoVenda == null) entity.precoVenda = retorno.Result.precoVenda;
      if (entity.estoque == null) entity.estoque = retorno.Result.estoque;
      if (entity.descricao == null) entity.descricao = retorno.Result.descricao;
      if (entity.Fabricante == null) entity.descricao = retorno.Result.Fabricante;
      if (entity.status == null) entity.status = retorno.Result.status;
      if (entity.dataCadastro == null) entity.dataCadastro = retorno.Result.dataCadastro;

      var update = _context.Produtos.Update(entity).Entity;
      _context.SaveChanges();
      return update;
      
    }

  }
}
