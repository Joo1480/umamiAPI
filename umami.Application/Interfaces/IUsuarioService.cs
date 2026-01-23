using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;
using umami.Domain.Entities;

namespace umami.Application.Interfaces
{
    public  interface IUsuarioService
    {
        Task<UsuarioDTO> Incluir(UsuarioPostDTO modelPostDTO);
        Task<UsuarioDTO> Alterar(UsuarioDTO modelDTO);
        Task<UsuarioDTO> Excluir(int id);
        Task<UsuarioDTO> SelecionarAsync(int id);
        Task<IEnumerable<UsuarioDTO>> SelecionarTodosAsync();
    }
}
