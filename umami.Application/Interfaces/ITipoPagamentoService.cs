using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;
using umami.Domain.Pagination;

namespace umami.Application.Interfaces
{
    public interface ITipoPagamentoService
    {
        Task<TipoPagamentoDTO> Incluir(TipoPagamentoDTO modelDTO);
        Task<TipoPagamentoDTO> Alterar(TipoPagamentoDTO modelDTO);
        Task<TipoPagamentoDTO> Excluir(int id);
        Task<TipoPagamentoDTO> SelecionarAsync(int id);
        Task<PagedList<TipoPagamentoDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}
