using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using umami.Application.DTOs;
using umami.Application.Interfaces;

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
            var userid = int.Parse(User.FindFirst("id").Value);
            var usuario = await _usuarioService.SelecionarAsync(userid);

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
            var userid = int.Parse(User.FindFirst("id").Value);
            var usuario = await _usuarioService.SelecionarAsync(userid);

            if (usuario.SEQTIPOUSUARIO != 1)
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
            var userid = int.Parse(User.FindFirst("id").Value);
            var usuario = await _usuarioService.SelecionarAsync(userid);

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
    }
}
