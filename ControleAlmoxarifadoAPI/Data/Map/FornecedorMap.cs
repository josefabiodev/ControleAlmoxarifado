using ControleAlmoxarifadoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleAlmoxarifadoAPI.Data.Map
{
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorModel>
    {
        public void Configure(EntityTypeBuilder<FornecedorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Endereco).HasMaxLength(150);
            builder.Property(x => x.Contato).HasMaxLength(15);
            builder.Property(x => x.CNPJ).HasMaxLength(17);
    }
    }
}
