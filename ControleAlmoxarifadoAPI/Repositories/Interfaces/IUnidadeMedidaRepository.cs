using ControleAlmoxarifadoAPI.Models;

namespace ControleAlmoxarifadoAPI.Repositories.Interfaces
{
    public interface IUnidadeMedidaRepository
    {
        Task<List<UnidadeMedidaModel>> BuscarTodaUnidadeMedida();
        Task<UnidadeMedidaModel> BuscarUnidadeMedidaPorId(int id);
        Task<UnidadeMedidaModel> AdicionarUnidadeMedida(UnidadeMedidaModel unidadeMedida);
        Task<UnidadeMedidaModel> AtualizarUnidadeMedida(UnidadeMedidaModel unidadeMedida, int id);
        Task<bool> ExcluirUnidadeMedida(int id);
    }
}
