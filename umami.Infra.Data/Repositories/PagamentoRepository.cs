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
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly ApplicationDbContext _context;
        public PagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PAGAMENTO> Incluir(PAGAMENTO pagamento)
        {
            _context.PAGAMENTO.Add(pagamento);
            await _context.SaveChangesAsync();
            return pagamento;
        }
        public async Task IncluirRange(IEnumerable<PAGAMENTO> pagamentos)
        {
            _context.PAGAMENTO.AddRange(pagamentos);
            await _context.SaveChangesAsync();
        }
    }
}
