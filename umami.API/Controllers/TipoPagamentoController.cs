using Microsoft.AspNetCore.Mvc;
using umami.API.Extensions;
using umami.API.Models;
using umami.Application.DTOs;
using umami.Application.Interfaces;

namespace umami.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TipoPagamentoController : Controller
    {
        private readonly ITipoPagamentoService _tipoPagService;
        private readonly IUsuarioService _usuarioService;
        public TipoPagamentoController(ITipoPagamentoService tipoPagService, IUsuarioService usuarioService)
        {
            _tipoPagService = tipoPagService;
            _usuarioService = usuarioService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Incluir(TipoPagamentoDTO modelDTO)
        {
            //var userId = User.Getid();
            //var usuario = await _usuarioService.SelecionarAsync(userId);

            //if (usuario.SEQTIPOUSUARIO != 1)
            //{
            //    return Unauthorized("Você não tem permissão para incluir o Tipo de Usuário");
            //}
            var TipoPagDTOIncluido = await _tipoPagService.Incluir(modelDTO);
            if (TipoPagDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o Tipo de Pagamento!");
            }
            return Ok("Tipo de Pagamento incluido com Sucesso!");
        }
        [HttpPut]
        public async Task<ActionResult> Alterar(TipoPagamentoDTO modelDTO)
        {
            //var userId = User.Getid();
            //var usuario = await _usuarioService.SelecionarAsync(userId);

            //if (usuario.SEQTIPOUSUARIO != 2)
            //{
            //    return Unauthorized("Você não tem permissão para alterar o Tipo de Usuário");
            //}
            var TipoPagDTOIncluido = await _tipoPagService.Alterar(modelDTO);
            if (TipoPagDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o tipo do pagamento!");
            }
            return Ok("Tipo de Pagamento alterado com Sucesso!");
        }
        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            //var userId = User.Getid();
            //var usuario = await _usuarioService.SelecionarAsync(userId);

            //if (usuario.SEQTIPOUSUARIO != 1)
            //{
            //    return Unauthorized("Você não tem permissão para excluir o Tipo de Usuário");
            //}

            var tipoPagDTOExcluido = await _tipoPagService.Excluir(id);
            if (tipoPagDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o tipo de pagamento!");
            }
            return Ok("Tipo de Pagamento excluido com Sucesso!");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var modelDTO = await _tipoPagService.SelecionarAsync(id);
            if (modelDTO == null)
            {
                return NotFound("Tipo de Pagamento não encontrado");
            }
            return Ok(modelDTO);
        }
        [HttpGet]
        public async Task<ActionResult> SelecionarTodos([FromQuery] PaginationParams paginationParams)
        {
            var modelDTO = await _tipoPagService.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(modelDTO.CurrentPage, modelDTO.PageSize, modelDTO.TotalCount, modelDTO.TotalPages));
            return Ok(modelDTO);
        }
    }
}
