using Microsoft.AspNetCore.Mvc;
using umami.Application.DTOs;
using umami.Application.Interfaces;

namespace umami.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PagamentoController : Controller
    {
        private readonly IPagamentoService _pagamentoService;
        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }
        [HttpPost("pagamento")]
        public async Task<IActionResult> Criar([FromBody] PagamentoDTO model)
        {
            if (model == null || model.TipoValores == null || !model.TipoValores.Any())
                return BadRequest("O pagamento deve conter ao menos um item.");

            var pagamentoId = await _pagamentoService.Incluir(model);

            return Ok("Pagamento realizada com Sucesso!");
        }
    }
}
