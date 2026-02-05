using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;

namespace umami.Application.Interfaces
{
    public interface IVendaService
    {
        Task<int> Incluir(VendaDTO model);
        Task<bool> VerificaVendaAberto(int seqUsuario);
    }
}
