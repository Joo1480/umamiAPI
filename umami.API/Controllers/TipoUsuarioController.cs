using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using umami.API.Extensions;
using umami.API.Models;
using umami.Application.DTOs;
using umami.Application.Interfaces;
using umami.Infra.Data.Helpers;
using umami.Infra.Ioc;

namespace umami.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TipoUsuarioController : Controller
    {
        private readonly ITipoUsuarioService _tipoUsuService;
        private readonly IUsuarioService _usuarioService;
        public TipoUsuarioController(ITipoUsuarioService tipoUsuService, IUsuarioService usuarioService)
        {
            _tipoUsuService = tipoUsuService;
            _usuarioService = usuarioService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Incluir(TipoUsuarioDTO modelDTO)
        {
            var userId = User.Getid();
            var usuario = await _usuarioService.SelecionarAsync(userId);

            if (usuario.SEQTIPOUSUARIO != 1)
            {
                return Unauthorized("Você não tem permissão para incluir o Tipo de Usuário");
            }
            var TipoUsuDTOIncluido = await _tipoUsuService.Incluir(modelDTO);
            if (TipoUsuDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o Tipo de usuário!");
            }
            return Ok("Tipo de usuário incluido com Sucesso!");
        }
        [HttpPut]
        public async Task<ActionResult> Alterar(TipoUsuarioDTO modelDTO)
        {
            var userId = User.Getid();
            var usuario = await _usuarioService.SelecionarAsync(userId);

            if (usuario.SEQTIPOUSUARIO != 2)
            {
                return Unauthorized("Você não tem permissão para alterar o Tipo de Usuário");
            }
            var tipoUsuDTOIncluido = await _tipoUsuService.Alterar(modelDTO);
            if (tipoUsuDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o tipo do usuário");
            }
            return Ok("Tipo Usuário alterado com Sucesso!");
        }
        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var userId = User.Getid();
            var usuario = await _usuarioService.SelecionarAsync(userId);

            if (usuario.SEQTIPOUSUARIO != 1)
            {
                return Unauthorized("Você não tem permissão para excluir o Tipo de Usuário");
            }
            
            var tipoUsuDTOExcluido = await _tipoUsuService.Excluir(id);
            if (tipoUsuDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o tipo de usuário");
            }
            return Ok("Tipo de usuário excluido com Sucesso!");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var modelDTO = await _tipoUsuService.SelecionarAsync(id);
            if (modelDTO == null)
            {
                return NotFound("Tipo de Usuário não encontrado");
            }
            return Ok(modelDTO);
        }
        [HttpGet]
        public async Task<ActionResult> SelecionarTodos([FromQuery]PaginationParams paginationParams)
        {
            var modelDTO = await _tipoUsuService.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(modelDTO.CurrentPage, modelDTO.PageSize, modelDTO.TotalCount, modelDTO.TotalPages));
            return Ok(modelDTO);
        }
    }
}
