using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace umami.Application.DTOs
{
    public class ItensVendaDTO
    {
        public int SEQPRODUTO { get; set; }
        public int QUANT { get; set; }
        [JsonIgnore]
        public decimal VALOR { get; set; }
    }
}
