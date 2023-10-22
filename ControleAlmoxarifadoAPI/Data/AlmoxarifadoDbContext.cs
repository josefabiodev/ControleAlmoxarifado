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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
