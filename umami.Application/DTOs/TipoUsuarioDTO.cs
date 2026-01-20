using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace umami.Application.DTOs
{
    public class TipoUsuarioDTO
    {
        [IgnoreDataMember]
        public int ID { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório")]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres")]
        public string? DESCRICAO { get; set; }
    }
}
