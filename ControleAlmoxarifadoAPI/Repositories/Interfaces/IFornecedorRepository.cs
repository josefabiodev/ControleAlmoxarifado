using ControleAlmoxarifadoAPI.Models;

namespace ControleAlmoxarifadoAPI.Repositories.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<List<FornecedorModel>> BuscarTodasFornecedores();
        Task<FornecedorModel> BuscarFornecedorPorId(int id);
        Task<FornecedorModel> AdicionarFornecedor(FornecedorModel fornecedor);
        Task<FornecedorModel> AtualizarFornecedor(FornecedorModel fornecedor, int id);
        Task<bool> ExcluirFornecedor(int id);
    }
}
