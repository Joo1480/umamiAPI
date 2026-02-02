using Microsoft.AspNetCore.Mvc;
using umami.API.Extensions;
using umami.API.Models;
using umami.Application.DTOs;
using umami.Application.Interfaces;
using umami.Infra.Ioc;

namespace umami.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IUsuarioService _usuarioService;
        public ProdutoController(IProdutoService produtoService, IUsuarioService usuarioService)
        {
            _produtoService = produtoService;
            _usuarioService = usuarioService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Incluir(ProdutoDTO modelDTO)
        {
            //var userId = User.Getid();
            //var usuario = await _usuarioService.SelecionarAsync(userId);

            //if (usuario.SEQTIPOUSUARIO != 1)
            //{
            //    return Unauthorized("Você não tem permissão para incluir Produto!");
            //}
            var produtoIncluido = await _produtoService.Incluir(modelDTO);
            if (produtoIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o Produto!");
            }
            return Ok("Produto incluido com Sucesso!");
        }
        [HttpPut]
        public async Task<ActionResult> Alterar(ProdutoDTO modelDTO)
        {
            //var userId = User.Getid();
            //var usuario = await _usuarioService.SelecionarAsync(userId);

            //if (usuario.SEQTIPOUSUARIO != 2)
            //{
            //    return Unauthorized("Você não tem permissão para alterar o Tipo de Usuário");
            //}
            var produtoAlterado = await _produtoService.Alterar(modelDTO);
            if (produtoAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o produto!");
            }
            return Ok("Produto alterado com Sucesso!");
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

            var produtoExcluido = await _produtoService.Excluir(id);
            if (produtoExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o produto!");
            }
            return Ok("Produto excluido com Sucesso!");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var modelDTO = await _produtoService.SelecionarAsync(id);
            if (modelDTO == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(modelDTO);
        }
        [HttpGet]
        public async Task<ActionResult> SelecionarTodos([FromQuery] PaginationParams paginationParams)
        {
            var modelDTO = await _produtoService.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(modelDTO.CurrentPage, modelDTO.PageSize, modelDTO.TotalCount, modelDTO.TotalPages));
            return Ok(modelDTO);
        }
    }
}
