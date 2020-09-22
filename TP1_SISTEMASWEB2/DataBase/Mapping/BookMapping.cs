using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TP1_SISTEMASWEB2.Entidades;

namespace TP1_SISTEMASWEB2.DataBase.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();

            builder.Property(x => x.nome)
                .IsRequired();

            builder.Property(x => x.price)
                .IsRequired();

            builder.Property(x => x.qty)
                .IsRequired();

        }
    }
}
