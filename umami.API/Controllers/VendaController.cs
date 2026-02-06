using Microsoft.AspNetCore.Mvc;
using umami.Application.DTOs;
using umami.Application.Interfaces;
using umami.Domain.Entities;
using umami.Infra.Ioc;

namespace umami.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class VendaController : Controller
    {
        private readonly IVendaService _vendaService;
        private readonly IProdutoService _produtoService;
        public VendaController(IVendaService vendaService, IProdutoService produtoService)
        {
            _vendaService = vendaService;
            _produtoService = produtoService;
        }
        [HttpPost("novaVenda")]
        public async Task<IActionResult> Criar([FromBody] VendaDTO model)
        {
            if (model == null || model.Itens == null || !model.Itens.Any())
                return BadRequest("A venda deve conter ao menos um item.");

            //var vendaEmAberto = await _vendaService.VerificaVendaAberto(User.Getid());
            //var vendaEmAberto = await _vendaService.VerificaVendaAberto(1);
            //if (vendaEmAberto)
            //{
            //    return BadRequest("Possui venda em aberto, finalize ela antes de incluir uma nova!");
            //}
            model.STATUS = false;
            //model.SEQUSUARIO = User.Getid();
            model.SEQUSUARIO = 1;

            var vendaId = await _vendaService.Incluir(model);

            return Ok("Venda realizada com Sucesso!"); 
        }
    }
}
