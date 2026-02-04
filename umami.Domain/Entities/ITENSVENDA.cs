using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Validation;

namespace umami.Domain.Entities
{
    public class ITENSVENDA
    {
        public int ID { get; private set; }
        public int QUANT { get; private set; }
        public decimal VALOR { get; private set; }
        public int SEQPRODUTO { get; private set; }
        public int SEQVENDA { get; private set; }
        public PRODUTO PRODUTO { get; set; } 
        public VENDA VENDA { get; set; }
        protected ITENSVENDA() { }
        public ITENSVENDA(int id, int quant, decimal valor, int seqproduto, int seqvenda)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            ID = id;
            QUANT = quant;
            VALOR = valor;
            SEQPRODUTO = seqproduto;
            SEQVENDA = seqvenda;
        }
        public ITENSVENDA(int quant, decimal valor, int seqproduto)
        {
            QUANT = quant;
            VALOR = valor * quant;
            SEQPRODUTO = seqproduto;
        }
        public ITENSVENDA(int quant, decimal valor, int seqproduto, int seqvenda)
        {
            ValidateDomain(quant,  valor, seqproduto, seqvenda);
        }
        private void ValidateDomain(int quant, decimal valor, int seqproduto, int seqvenda)
        {
            DomainExceptionValidation.When(quant > 0, "A quantidade deve ser mais que zero.");
            QUANT = quant;
            VALOR = valor;
            SEQPRODUTO = seqproduto;
            SEQVENDA = seqvenda;
        }
    }
}
