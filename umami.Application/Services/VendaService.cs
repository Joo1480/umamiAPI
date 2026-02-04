using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;
using umami.Application.Interfaces;
using umami.Domain.Entities;
using umami.Domain.Interfaces;
using umami.Infra.Data.Repositories;

namespace umami.Application.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public VendaService(IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
        }
        public async Task<int> Incluir(VendaDTO model)
        {
            var venda = new VENDA(DateTime.Now, model.STATUS, model.SEQUSUARIO);

            foreach (var item in model.Itens)
            {
                var valorProd = await _produtoRepository.ObterValorProduto(item.SEQPRODUTO);
                item.VALOR = valorProd;
                venda.AdicionarItem(item.QUANT, item.VALOR, item.SEQPRODUTO);
            }
            await _vendaRepository.Incluir(venda);

            // 4️⃣ Retorna o ID gerado
            return venda.ID;
        }
    }
}
