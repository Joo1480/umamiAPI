using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;
using umami.Domain.Pagination;

namespace umami.Infra.Data.Repositories
{
    public interface IProdutoRepository
    {
        Task<PRODUTO> Incluir(PRODUTO model);
        Task<PRODUTO> Alterar(PRODUTO model);
        Task<PRODUTO> Excluir(int id);
        Task<PRODUTO> SelecionarAsync(int id);
        Task<PagedList<PRODUTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<decimal> ObterValorProduto(int id);
        Task<bool> VerificaDisponibilidade(int id);
    }
}
