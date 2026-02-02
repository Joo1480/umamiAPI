using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;
using umami.Domain.Pagination;

namespace umami.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> Incluir(ProdutoDTO modelDTO);
        Task<ProdutoDTO> Alterar(ProdutoDTO modelDTO);
        Task<ProdutoDTO> Excluir(int id);
        Task<ProdutoDTO> SelecionarAsync(int id);
        Task<PagedList<ProdutoDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}
