using ControleAlmoxarifadoAPI.Models;

namespace ControleAlmoxarifadoAPI.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<CategoriaModel>> BuscarTodasCategorias();
        Task<CategoriaModel> BuscarCategoriaPorId(int id);
        Task<CategoriaModel> AdicionarCategoria(CategoriaModel categoria);
        Task<CategoriaModel> AtualizarCategoria(CategoriaModel categoria, int id);
        Task<bool> ExcluirCategoria(int id);
    }
}
