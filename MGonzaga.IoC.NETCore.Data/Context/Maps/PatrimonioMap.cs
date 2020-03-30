using MGonzaga.IoC.NETCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MGonzaga.IoC.NETCore.Data.Context.Maps
{
    public class PatrimonioMap : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.Property(p => p.Nome).IsRequired(true).HasMaxLength(100);
            builder.Property(p => p.Descricao).IsRequired(true).HasMaxLength(1000);
            builder.Property(p => p.NumeroTombo).IsRequired(true);
            builder.HasIndex(i => i.NumeroTombo).IsUnique(true);
        }
    }
}
