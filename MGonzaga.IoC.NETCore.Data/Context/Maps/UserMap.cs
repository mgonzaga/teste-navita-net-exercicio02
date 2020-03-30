using MGonzaga.IoC.NETCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Data.Context.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FullName)
                            .IsRequired(true)
                            .HasMaxLength(100);
            builder.Property(p => p.Email)
                        .IsRequired(true)
                        .HasMaxLength(200);
           
            builder.Property(p => p.Password)
                            .IsRequired(true)
                            .HasMaxLength(10);

            builder.HasIndex(i => i.Email).IsUnique(true);

        }
    }
}
