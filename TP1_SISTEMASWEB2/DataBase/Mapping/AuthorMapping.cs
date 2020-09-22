using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TP1_SISTEMASWEB2.Entidades;

namespace TP1_SISTEMASWEB2.DataBase.Mapping
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();

            builder.Property(x => x.name)
                .IsRequired();

            builder.Property(x => x.email)
                .IsRequired();

            builder.Property(x => x.gender)
                .IsRequired();

        }
    }
}
