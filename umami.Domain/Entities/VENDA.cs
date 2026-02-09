using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Validation;

namespace umami.Domain.Entities
{
    public class VENDA
    {
        public int ID { get; private set; }
        public DateTime DATA_VENDA { get; private set; }
        public bool STATUS { get; private set; }
        public int SEQUSUARIO { get; private set; }
        public USUARIO USUARIO { get; set; }
        public ICollection<ITENSVENDA> ITENSVENDA { get; } = new List<ITENSVENDA>();
        public ICollection<PAGAMENTO> PAGAMENTO { get; set; }
        public void AdicionarItem(int quant, decimal valor, int seqProduto)
        {
            ITENSVENDA.Add(new ITENSVENDA(quant, valor, seqProduto));
        }
        protected VENDA() { }
        public VENDA(int id, DateTime dataVenda, bool status, int seqUsuario)
        {
            DomainExceptionValidation.When(id < 0, "Id da venda deve ser positivo.");
            ID = id;
            DATA_VENDA = dataVenda;
            STATUS = status;
            SEQUSUARIO = seqUsuario;
            ValidateDomain(dataVenda, status, seqUsuario);
        }
        public VENDA(DateTime dataVenda, bool status, int seqUsuario)
        {
            ValidateDomain(dataVenda, status, seqUsuario);
        }
        private void ValidateDomain(DateTime dataVenda, bool status, int seqUsuario)
        {
            DATA_VENDA = dataVenda;
            STATUS = status;
            SEQUSUARIO = seqUsuario;
        }

    }
}
