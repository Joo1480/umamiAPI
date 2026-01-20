using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;

namespace umami.Domain.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        Task<TIPOUSUARIO> Incluir(TIPOUSUARIO model);
        Task<TIPOUSUARIO> Alterar(TIPOUSUARIO model);
        Task<TIPOUSUARIO> Excluir(int id);
        Task<TIPOUSUARIO> SelecionarAsync(int id);
        Task<IEnumerable<TIPOUSUARIO>> SelecionarTodosAsync(int id);
    }
}
