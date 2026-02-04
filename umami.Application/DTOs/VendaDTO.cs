using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace umami.Application.DTOs
{
    public class VendaDTO
    {
        [JsonIgnore]
        public DateTime DATA_VENDA { get; set; }
        public bool STATUS { get; set; }
        [JsonIgnore]
        public int SEQUSUARIO { get; set; }
        public List<ItensVendaDTO> Itens { get; set; }
    }
}
