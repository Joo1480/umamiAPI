using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;

namespace umami.Domain.Interfaces
{
    public interface IVendaRepository
    {
        public Task<VENDA> Incluir(VENDA model);
    }
}
