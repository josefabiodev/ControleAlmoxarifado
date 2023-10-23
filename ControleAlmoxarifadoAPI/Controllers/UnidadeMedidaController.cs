using ControleAlmoxarifadoAPI.Models;
using ControleAlmoxarifadoAPI.Repositories;
using ControleAlmoxarifadoAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleAlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly IUnidadeMedidaRepository _unidadeMedidaRepository;

        public UnidadeMedidaController(IUnidadeMedidaRepository unidadeMedidaRepository)
        {
            _unidadeMedidaRepository = unidadeMedidaRepository;
        }

        [HttpPost]
        public async Task<ActionResult<UnidadeMedidaModel>> AdicionarUnidadeMedida([FromBody] UnidadeMedidaModel unidadeMedidaModel)
        {
            UnidadeMedidaModel unidadeMedida = await _unidadeMedidaRepository.AdicionarUnidadeMedida(unidadeMedidaModel);
            return Ok(unidadeMedida);
        }

        [HttpGet]
        public async Task<ActionResult<UnidadeMedidaModel>> BuscarTodaUnidadeMedida()
        {
            List<UnidadeMedidaModel> unidadeMedida = await _unidadeMedidaRepository.BuscarTodaUnidadeMedida();
            return Ok(unidadeMedida);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeMedidaModel>> BuscarUnidadeMedidaPorId(int id)
        {
            UnidadeMedidaModel unidadeMedida = await _unidadeMedidaRepository.BuscarUnidadeMedidaPorId(id);
            return Ok(unidadeMedida);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UnidadeMedidaModel>> AtualizarUnidadeMedida([FromBody] UnidadeMedidaModel unidadeMedidaModel, int id)
        {
            unidadeMedidaModel.Id = id;
            UnidadeMedidaModel unidadeMedida = await _unidadeMedidaRepository.AtualizarUnidadeMedida(unidadeMedidaModel, id);
            return Ok(unidadeMedida);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UnidadeMedidaModel>> ExcluirUnidadeMedida(int id)
        {
            bool exclusao = await _unidadeMedidaRepository.ExcluirUnidadeMedida(id);
            return Ok(exclusao);
        }
    }
}
