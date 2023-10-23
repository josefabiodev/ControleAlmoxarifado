using ControleAlmoxarifadoAPI.Data;
using ControleAlmoxarifadoAPI.Models;
using ControleAlmoxarifadoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAlmoxarifadoAPI.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AlmoxarifadoDbContext _dbContext;

        public CategoriaRepository(AlmoxarifadoDbContext almoxarifadoDbContext)
        {
            _dbContext = almoxarifadoDbContext;
        }

        public async Task<CategoriaModel> AdicionarCategoria(CategoriaModel categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
            return categoria;
        }        

        public async Task<CategoriaModel> BuscarCategoriaPorId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriaModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async Task<CategoriaModel> AtualizarCategoria(CategoriaModel categoria, int id)
        {
            CategoriaModel categoriaPorId = await BuscarCategoriaPorId(id);
            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria para o ID; {id} não foi encontrada no banco de dados.");
            }

            categoriaPorId.Nome = categoria.Nome;

            _dbContext.Categorias.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();
            return categoriaPorId;
        }

        public async Task<bool> ExcluirCategoria(int id)
        {
            CategoriaModel categoriaPorId = await BuscarCategoriaPorId(id);
            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria para o ID; {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Categorias.Remove(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
