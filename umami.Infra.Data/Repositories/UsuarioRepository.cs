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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<USUARIO> Incluir(USUARIO model)
        {
            _context.USUARIO.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<USUARIO> Alterar(USUARIO model)
        {
            _context.USUARIO.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<USUARIO> Excluir(int id)
        {
            var tipo = await _context.USUARIO.FindAsync(id);
            if (tipo != null)
            {
                _context.USUARIO.Remove(tipo);
                await _context.SaveChangesAsync();
                return tipo;
            }
            return null;
        }
        public async Task<USUARIO> SelecionarAsync(int id)
        {
            return await _context.USUARIO.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<USUARIO>> SelecionarTodosAsync()
        {
            return await _context.USUARIO.Include(x => x.TIPOUSUARIO).ToListAsync();
        }
    }
}
