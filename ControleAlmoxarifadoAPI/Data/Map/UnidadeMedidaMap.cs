using ControleAlmoxarifadoAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleAlmoxarifadoAPI.Data.Map
{
    public class UnidadeMedidaMap : IEntityTypeConfiguration<UnidadeMedidaModel>
    {
        public void Configure(EntityTypeBuilder<UnidadeMedidaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
        }
    }
}
