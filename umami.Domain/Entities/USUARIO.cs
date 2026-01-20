using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Validation;

namespace umami.Domain.Entities
{
    public class USUARIO
    {
        public int ID { get; private set; }
        public string? NOME { get; private set; }
        public string? EMAIL { get; private set; }
        public string? CELULAR { get; private set; }
        public string? CEP { get; private set; }
        public string? NUMENDERECO { get; private set; }
        public string? COMPLEMENTO { get; private set; }
        public string? CPF { get; private set; }
        public int? SEQTIPOUSUARIO { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public TIPOUSUARIO TIPOUSUARIO { get; set; }
        protected USUARIO() { }
        public USUARIO(int id, string? nome, string? email, string? celular, string? cep, string? numendereco, string? complemento, string? cpf, int? seqtipousuario)
        {
            DomainExceptionValidation.When(id < 0, "O id não poder menor que 0");
            ID = id;
            NOME = nome;
            EMAIL = email;
            CELULAR = celular;
            CEP = cep;
            NUMENDERECO = numendereco;
            COMPLEMENTO = complemento;
            CPF = cpf;
            SEQTIPOUSUARIO = seqtipousuario;
            ValidateDomain(nome, email, celular, cep, numendereco, complemento, cpf, seqtipousuario);
        }
        public USUARIO(string? nome, string? email, string? celular, string? cep, string? numendereco, string? complemento, string? cpf, int? seqtipousuario)
        {
            ValidateDomain(nome, email, celular, cep, numendereco, complemento, cpf, seqtipousuario);
        }
        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        private void ValidateDomain(string? nome, string? email, string? celular, string? cep, string? numendereco, string? complemento, string? cpf, int? seqtipousuario)
        {
            DomainExceptionValidation.When(nome == null, "O nome é obrigatório");
            DomainExceptionValidation.When(email == null, "O email é obrigatório");
            DomainExceptionValidation.When(nome.Length > 250, "O nome não pode ultrapassar 250 caracteres");
            DomainExceptionValidation.When(email.Length > 250, "O email não pode ultrapassar 250 caracteres");
            NOME = nome;
            EMAIL = email;
            CELULAR = celular;
            CEP = cep;
            NUMENDERECO = numendereco;
            COMPLEMENTO = complemento;
            CPF = cpf;
            SEQTIPOUSUARIO = seqtipousuario;
        }
    }
}
