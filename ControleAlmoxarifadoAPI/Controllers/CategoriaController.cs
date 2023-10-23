using ControleAlmoxarifadoAPI.Models;
using ControleAlmoxarifadoAPI.Repositories;
using ControleAlmoxarifadoAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleAlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaModel>> AdicionarCategoria([FromBody] CategoriaModel categoriaModel)
        {
            CategoriaModel categoria = await _categoriaRepository.AdicionarCategoria(categoriaModel);
            return Ok(categoria);
        }

        [HttpGet]
        public async Task<ActionResult<CategoriaModel>> BuscarTodasCategorias()
        {
            List<CategoriaModel> categoria = await _categoriaRepository.BuscarTodasCategorias();
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> BuscarCategoriaPorId(int id)
        {
            CategoriaModel categoria = await _categoriaRepository.BuscarCategoriaPorId(id);
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaModel>> AtualizarCategoria([FromBody] CategoriaModel categoriaModel, int id)
        {
            categoriaModel.Id = id;
            CategoriaModel usuario = await _categoriaRepository.AtualizarCategoria(categoriaModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaModel>> ExcluirCategoria(int id)
        {
            bool exclusao = await _categoriaRepository.ExcluirCategoria(id);
            return Ok(exclusao);
        }
    }
}
