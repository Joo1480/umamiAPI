using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;

namespace umami.Domain.Interfaces
{
    public interface IPagamentoRepository
    {
        Task <PAGAMENTO> Incluir(PAGAMENTO pagamento);
        Task IncluirRange(IEnumerable<PAGAMENTO> pagamentos);
    }
}
