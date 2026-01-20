using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;
using umami.Domain.Interfaces;
using umami.Infra.Data.Context;

namespace umami.Infra.Data.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public TipoUsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TIPOUSUARIO> Incluir(TIPOUSUARIO model)
        {
            _context.TIPOUSUARIO.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<TIPOUSUARIO> Alterar(TIPOUSUARIO model)
        {
            _context.TIPOUSUARIO.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<TIPOUSUARIO> Excluir(int id)
        {
            var tipo = await _context.TIPOUSUARIO.FindAsync(id);
            if (tipo != null)
            {
                _context.TIPOUSUARIO.Remove(tipo);
                await _context.SaveChangesAsync();
                return tipo;
            }
            return null;
        }
        public async Task<TIPOUSUARIO> SelecionarAsync(int id)
        {
            return await _context.TIPOUSUARIO.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<TIPOUSUARIO>> SelecionarTodosAsync()
        {
            return await _context.TIPOUSUARIO.ToListAsync();
        }
    }
}
