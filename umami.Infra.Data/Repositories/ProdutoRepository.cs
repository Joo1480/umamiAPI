using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;
using umami.Domain.Pagination;
using umami.Infra.Data.Context;
using umami.Infra.Data.Helpers;

namespace umami.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PRODUTO> Incluir(PRODUTO model)
        {
            _context.PRODUTO.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<PRODUTO> Alterar(PRODUTO model)
        {
            _context.PRODUTO.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<PRODUTO> Excluir(int id)
        {
            var produto = await _context.PRODUTO.FindAsync(id);
            if (produto != null)
            {
                _context.PRODUTO.Remove(produto);
                await _context.SaveChangesAsync();
                return produto;
            }
            return null;
        }
        public async Task<PRODUTO> SelecionarAsync(int id)
        {
            return await _context.PRODUTO.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<PagedList<PRODUTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.PRODUTO.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }
    }
}
