using Microsoft.AspNetCore.Mvc;
using umami.API.Models;
using umami.Application.DTOs;
using umami.Application.Interfaces;
using umami.Domain.Account;

namespace umami.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioPostDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Dados Inválidos");
            }
            var emailExiste = await _authenticateService.UserExists(usuarioDTO.EMAIL);

            if (emailExiste)
            {
                return BadRequest("Este e-mail já possui um cadastro.");
            }

            var usuario = await _usuarioService.Incluir(usuarioDTO);
            if (usuario == null)
            {
                return BadRequest("Ocorreu erro ao cadastrar");
            }
            var token = _authenticateService.GenerateToken(usuario.ID, usuario.EMAIL);

            return new UserToken
            {
                Token = token
            };

        }
        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel)
        {
            var existe = await _authenticateService.UserExists(loginModel.Email);
            if (!existe)
            {
                return Unauthorized("Usuário não existe.");
            }
            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result)
            {
                return Unauthorized("Usuário ou senha errado.");
            }

            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(usuario.ID, usuario.EMAIL);

            return new UserToken
            {
                Token = token
            };
        }
        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var modelDTO = await _usuarioService.SelecionarTodosAsync();
            return Ok(modelDTO);
        }
    }
}
