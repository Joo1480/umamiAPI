using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;
using umami.Application.Interfaces;
using umami.Domain.Entities;
using umami.Domain.Interfaces;

namespace umami.Application.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        public PagamentoService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }
        public async Task<int> Incluir(PagamentoDTO model)
        {
            var pagamentos = new List<PAGAMENTO>();

            foreach (var item in model.TipoValores)
            {
                pagamentos.Add(new PAGAMENTO(DateTime.Now,item.VALOR_PAGAMENTO, item.SEQTIPOPAGAMENTO, model.SEQVENDA));
            }

            await _pagamentoRepository.IncluirRange(pagamentos);

            return pagamentos.Count;
        }
    }
}
