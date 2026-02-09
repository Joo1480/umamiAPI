using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Validation;

namespace umami.Domain.Entities
{
    public class PAGAMENTO
    {
        public int ID { get; private set; }
        public DateTime DATA_PAGAMENTO { get; private set; }
        public decimal VALOR_PAGAMENTO { get; private set; }
        public int SEQTIPOPAGAMENTO { get; private set; }
        public int SEQVENDA { get; private set; }
        public TIPOPAGAMENTO TIPOPAGAMENTO { get; set; }
        public VENDA VENDA { get; set; }
        protected PAGAMENTO() { }
        public PAGAMENTO(int id, DateTime dataPagamento, decimal valorPagamento, int seqTipoPagamento, int seqVenda)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            ID = id;
            DATA_PAGAMENTO = dataPagamento;
            VALOR_PAGAMENTO = valorPagamento;
            SEQTIPOPAGAMENTO = seqTipoPagamento;
            SEQVENDA = seqVenda;
        }
        public PAGAMENTO(DateTime dataPagamento, decimal valorPagamento, int seqTipoPagamento, int seqVenda)
        {
            ValidateDomain(dataPagamento, valorPagamento, seqTipoPagamento, seqVenda);
        }
        private void ValidateDomain(DateTime dataPagamento, decimal valorPagamento, int seqTipoPagamento, int seqVenda)
        {
            DATA_PAGAMENTO = dataPagamento;
            VALOR_PAGAMENTO = valorPagamento;
            SEQTIPOPAGAMENTO = seqTipoPagamento;
            SEQVENDA = seqVenda;
        }
    }
}
