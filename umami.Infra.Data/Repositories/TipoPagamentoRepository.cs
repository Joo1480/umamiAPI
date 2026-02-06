using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;
using umami.Domain.Interfaces;
using umami.Domain.Pagination;
using umami.Infra.Data.Context;
using umami.Infra.Data.Helpers;

namespace umami.Infra.Data.Repositories
{
    public class TipoPagamentoRepository : ITipoPagamentoRepository
    {
        private readonly ApplicationDbContext _context;
        public TipoPagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TIPOPAGAMENTO> Incluir(TIPOPAGAMENTO model)
        {
            _context.TIPOPAGAMENTO.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<TIPOPAGAMENTO> Alterar(TIPOPAGAMENTO model)
        {
            _context.TIPOPAGAMENTO.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<TIPOPAGAMENTO> Excluir(int id)
        {
            var tipo = await _context.TIPOPAGAMENTO.FindAsync(id);
            if (tipo != null)
            {
                _context.TIPOPAGAMENTO.Remove(tipo);
                await _context.SaveChangesAsync();
                return tipo;
            }
            return null;
        }
        public async Task<TIPOPAGAMENTO> SelecionarAsync(int id)
        {
            return await _context.TIPOPAGAMENTO.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<PagedList<TIPOPAGAMENTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.TIPOPAGAMENTO.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }
    }
}
