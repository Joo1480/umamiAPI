using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;

namespace umami.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<USUARIO> Incluir(USUARIO model);
        Task<USUARIO> Alterar(USUARIO model);
        Task<USUARIO> Excluir(int id);
        Task<USUARIO> SelecionarAsync(int id);
        Task<IEnumerable<USUARIO>> SelecionarTodosAsync();
    }
}
