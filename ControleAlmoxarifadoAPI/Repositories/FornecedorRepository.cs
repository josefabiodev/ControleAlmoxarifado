using ControleAlmoxarifadoAPI.Data;
using ControleAlmoxarifadoAPI.Models;
using ControleAlmoxarifadoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleAlmoxarifadoAPI.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AlmoxarifadoDbContext _dbContext;

        public FornecedorRepository(AlmoxarifadoDbContext almoxarifadoDbContext)
        {
            _dbContext = almoxarifadoDbContext;
        }

        public async Task<FornecedorModel> AdicionarFornecedor(FornecedorModel fornecedor)
        {
            await _dbContext.Fornecedores.AddAsync(fornecedor);
            await _dbContext.SaveChangesAsync();
            return fornecedor;
        }        

        public async Task<FornecedorModel> BuscarFornecedorPorId(int id)
        {
            return await _dbContext.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FornecedorModel>> BuscarTodasFornecedores()
        {
            return await _dbContext.Fornecedores.ToListAsync();
        }

        public async Task<FornecedorModel> AtualizarFornecedor(FornecedorModel fornecedor, int id)
        {
            FornecedorModel fornecedorPorId = await BuscarFornecedorPorId(id);
            if (fornecedorPorId == null)
            {
                throw new Exception($"Fornecedor para o ID; {id} não foi encontrado no banco de dados.");
            }

            fornecedorPorId.Nome = fornecedor.Nome;
            fornecedorPorId.Endereco = fornecedor.Endereco;
            fornecedorPorId.Contato = fornecedor.Contato;
            fornecedorPorId.CNPJ = fornecedor.CNPJ;

            _dbContext.Fornecedores.Update(fornecedorPorId);
            await _dbContext.SaveChangesAsync();
            return fornecedorPorId;
        }

        public async Task<bool> ExcluirFornecedor(int id)
        {
            FornecedorModel fornecedorPorId = await BuscarFornecedorPorId(id);
            if (fornecedorPorId == null)
            {
                throw new Exception($"Fornecedor para o ID; {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Fornecedores.Remove(fornecedorPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
