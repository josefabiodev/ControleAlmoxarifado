using ControleAlmoxarifadoAPI.Data.Map;
using ControleAlmoxarifadoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleAlmoxarifadoAPI.Data
{
    public class AlmoxarifadoDbContext : DbContext
    {
        public AlmoxarifadoDbContext(DbContextOptions<AlmoxarifadoDbContext> options)
            :base(options) 
        { 
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<UnidadeMedidaModel> UnidadeMedidas { get; set; }
        public DbSet<FornecedorModel> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new UnidadeMedidaMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
        }
    }
}
