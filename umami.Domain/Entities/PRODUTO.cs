using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Validation;

namespace umami.Domain.Entities
{
    public class PRODUTO
    {
        public int ID { get; private set; }
        public string? NOME { get; private set; }
        public string? DESCRICAO { get; private set; }
        public decimal? VALOR_VENDA { get; private set; }
        public bool STATUS {  get; private set; }
        protected PRODUTO() { }
        public PRODUTO(int id, string nome,  string descricao, decimal valorVenda, bool status)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            ID = id;
            NOME = nome;
            DESCRICAO = descricao;
            VALOR_VENDA = valorVenda;
            STATUS = status;
        }
        public PRODUTO(string nome, string descricao, decimal valorVenda, bool status)
        {
            ValidateDomain(nome, descricao, valorVenda, status);
        }
        private void ValidateDomain(string nome, string descricao, decimal valorVenda, bool status)
        {
            DomainExceptionValidation.When(nome == null, "O nome é obrigatório");
            DomainExceptionValidation.When(nome == null, "A descrição é obrigatória");
            DomainExceptionValidation.When(nome.Length > 250, "O nome não pode ultrapassar 250 caracteres");
            DomainExceptionValidation.When(descricao.Length > 250, "A descrição não pode ultrapassar 250 caracteres");
            NOME = nome;
            DESCRICAO = descricao;
            VALOR_VENDA = valorVenda;
            STATUS = status;
        }
    }
}
