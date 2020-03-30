using MGonzaga.IoC.NETCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Data.Context.Maps
{
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.Property(p => p.Id).HasField("MarcaId");
            builder.Property(p => p.Nome).IsRequired(true).HasMaxLength(50);
            builder.HasIndex(i => i.Nome).IsUnique(true);
            builder.HasMany(p => p.Patrimonios).WithOne(p => p.Marca);
        }
    }
}
