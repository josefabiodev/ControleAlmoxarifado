using ControleAlmoxarifadoAPI.Data;
using ControleAlmoxarifadoAPI.Models;
using ControleAlmoxarifadoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ControleAlmoxarifadoAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AlmoxarifadoDbContext _dbContext;

        public UsuarioRepository(AlmoxarifadoDbContext almoxarifadoDbContext)
        {
            _dbContext = almoxarifadoDbContext;
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioPorId(id) ?? 
                throw new Exception(
                    $"Usuário para o ID: {id} não foi encontrado no banco de dados"
                    );

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Username = usuario.Username;
            usuarioPorId.Password = usuario.Password;
            usuarioPorId.Nivel = usuario.Nivel;
            usuarioPorId.Status = usuario.Status;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;
        }        

        public async Task<bool> ExcluirUsuario(int id)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioPorId(id) ??
                throw new Exception(
                    $"Usuário para o ID: {id} não foi encontrado no banco de dados"
                    );

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
