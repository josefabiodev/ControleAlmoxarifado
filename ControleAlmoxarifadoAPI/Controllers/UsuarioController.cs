using ControleAlmoxarifadoAPI.Models;
using ControleAlmoxarifadoAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleAlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AdicionarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepository.AdicionarUsuario(usuarioModel);
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioModel>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuario = await _usuarioRepository.BuscarTodosUsuarios();
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepository.BuscarUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AtualizarUsuario([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepository.AtualizarUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> ExcluirUsuario(int id)
        {
            bool exclusao = await _usuarioRepository.ExcluirUsuario(id);
            return Ok(exclusao);
        }
    }
}
