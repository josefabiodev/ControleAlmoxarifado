using ControleAlmoxarifadoAPI.Models;
using ControleAlmoxarifadoAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleAlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorModel>> AdicionarFornecedor([FromBody] FornecedorModel fornecedorModel)
        {
            FornecedorModel fornecedor = await _fornecedorRepository.AdicionarFornecedor(fornecedorModel);
            return Ok(fornecedor);
        }

        [HttpGet]
        public async Task<ActionResult<FornecedorModel>> BuscarTodasFornecedors()
        {
            List<FornecedorModel> fornecedor = await _fornecedorRepository.BuscarTodasFornecedores();
            return Ok(fornecedor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorModel>> BuscarFornecedorPorId(int id)
        {
            FornecedorModel fornecedor = await _fornecedorRepository.BuscarFornecedorPorId(id);
            return Ok(fornecedor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FornecedorModel>> AtualizarFornecedor([FromBody] FornecedorModel fornecedorModel, int id)
        {
            fornecedorModel.Id = id;
            FornecedorModel fornecedor = await _fornecedorRepository.AtualizarFornecedor(fornecedorModel, id);
            return Ok(fornecedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FornecedorModel>> ExcluirFornecedor(int id)
        {
            bool exclusao = await _fornecedorRepository.ExcluirFornecedor(id);
            return Ok(exclusao);
        }
    }
}
