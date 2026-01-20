using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Validation;

namespace umami.Domain.Entities
{
    public class TIPOUSUARIO
    {
        public int ID { get; private set; }
        public string? DESCRICAO { get; private set; }
        protected TIPOUSUARIO() { }
        public TIPOUSUARIO(int id, string descricao)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            ID = id;
            ValidateDomain(descricao);
        }
        public TIPOUSUARIO(string descricao)
        {
            ValidateDomain(descricao);
        }
        public void Update(string descricao)
        {
            ValidateDomain(descricao);
        }
        public void ValidateDomain(string descricao)
        {
            DomainExceptionValidation.When(descricao.Length > 100, "A descrição não pode ter mais de 100 caracteres.");
            DESCRICAO = descricao;
        }
    }
}
