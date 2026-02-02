using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace umami.Application.DTOs
{
    public class ProdutoDTO
    {
        [IgnoreDataMember]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(250, ErrorMessage = "O nome deve ter no máximo 250 caracteres")]
        public string? NOME  { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(250, ErrorMessage = "A descrição deve ter no máximo 250 caracteres")]
        public string? DESCRICAO { get; set; }
        [Required(ErrorMessage = "O valor da venda é obrigatório")]
        public decimal? VALOR_VENDA { get; set; }
        public bool STATUS { get; set; }

    }
}
