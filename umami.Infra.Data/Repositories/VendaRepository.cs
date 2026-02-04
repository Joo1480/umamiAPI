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
    public class VendaRepository : IVendaRepository
    {
        private readonly ApplicationDbContext _context;
        public VendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<VENDA> Incluir(VENDA model)
        {
            _context.VENDA.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}

