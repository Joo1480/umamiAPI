using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umami.Application.DTOs
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres")]
        public string NOME { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MaxLength(200, ErrorMessage = "O e-mail não pode ter mais de 250 caracteres")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [MaxLength(100, ErrorMessage = "A senha não pode ter mais de 100 caracteres")]
        [MinLength(8, ErrorMessage = "A senha não pode ter menos de 8 caracteres")]
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public byte[]? PasswordHash { get; private set; }
        [NotMapped]
        public byte[]? PasswordSalt { get; private set; }
        public int? SEQTIPOUSUARIO { get; set; }
    }
}
