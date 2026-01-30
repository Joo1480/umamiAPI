using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;
using umami.Domain.Entities;
using umami.Domain.Pagination;

namespace umami.Application.Interfaces
{
    public interface ITipoUsuarioService
    {
        Task<TipoUsuarioDTO> Incluir(TipoUsuarioDTO modelDTO);
        Task<TipoUsuarioDTO> Alterar(TipoUsuarioDTO modelDTO);
        Task<TipoUsuarioDTO> Excluir(int id);
        Task<TipoUsuarioDTO> SelecionarAsync(int id);
        Task<PagedList<TipoUsuarioDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}
