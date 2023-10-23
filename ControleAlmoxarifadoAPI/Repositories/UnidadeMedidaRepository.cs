using ControleAlmoxarifadoAPI.Data;
using ControleAlmoxarifadoAPI.Models;
using ControleAlmoxarifadoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAlmoxarifadoAPI.Repositories
{
    public class UnidadeMedidaRepository : IUnidadeMedidaRepository
    {
        private readonly AlmoxarifadoDbContext _dbContext;

        public UnidadeMedidaRepository(AlmoxarifadoDbContext almoxarifadoDbContext)
        {
            _dbContext = almoxarifadoDbContext;
        }

        public async Task<UnidadeMedidaModel> AdicionarUnidadeMedida(UnidadeMedidaModel unidadeMedida)
        {
            await _dbContext.UnidadeMedidas.AddAsync(unidadeMedida);
            await _dbContext.SaveChangesAsync();
            return unidadeMedida;
        }

        public async Task<List<UnidadeMedidaModel>> BuscarTodaUnidadeMedida()
        {
            return await _dbContext.UnidadeMedidas.ToListAsync();
        }

        public async Task<UnidadeMedidaModel> BuscarUnidadeMedidaPorId(int id)
        {
            return await _dbContext.UnidadeMedidas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UnidadeMedidaModel> AtualizarUnidadeMedida(UnidadeMedidaModel unidadeMedida, int id)
        {
            UnidadeMedidaModel unidadeMedidaPorId = await BuscarUnidadeMedidaPorId(id);
            if (unidadeMedidaPorId == null)
            {
                throw new Exception($"unidadeMedida para o ID; {id} não foi encontrada no banco de dados.");
            }

            unidadeMedidaPorId.Nome = unidadeMedida.Nome;

            _dbContext.UnidadeMedidas.Update(unidadeMedidaPorId);
            await _dbContext.SaveChangesAsync();
            return unidadeMedidaPorId;
        }

        public async Task<bool> ExcluirUnidadeMedida(int id)
        {
            UnidadeMedidaModel unidadeMedidaPorId = await BuscarUnidadeMedidaPorId(id);
            if (unidadeMedidaPorId == null)
            {
                throw new Exception($"unidadeMedida para o ID; {id} não foi encontrada no banco de dados.");
            }

            _dbContext.UnidadeMedidas.Remove(unidadeMedidaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
