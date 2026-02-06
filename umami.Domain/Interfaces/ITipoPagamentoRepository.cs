using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;
using umami.Domain.Pagination;

namespace umami.Domain.Interfaces
{
    public interface ITipoPagamentoRepository
    {
        Task<TIPOPAGAMENTO> Incluir(TIPOPAGAMENTO model);
        Task<TIPOPAGAMENTO> Alterar(TIPOPAGAMENTO model);
        Task<TIPOPAGAMENTO> Excluir(int id);
        Task<TIPOPAGAMENTO> SelecionarAsync(int id);
        Task<PagedList<TIPOPAGAMENTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}
