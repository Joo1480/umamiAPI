using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace umami.Application.DTOs
{
    public class PagamentoDTO
    {
        [JsonIgnore]
        public DateTime DATA_PAGAMENTO { get; set; }
        public int SEQVENDA { get; set; }
        public required List<TipoValorPagamentoDTO> TipoValores { get; set; }        
    }
}
