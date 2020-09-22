using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TP1_SISTEMASWEB2.Entidades;

namespace TP1_SISTEMASWEB2.DataBase.Mapping
{
    public class AuthorBookMapping : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Author)
                .WithMany(x => x.AuthorBooks)
                .HasForeignKey(x => x.idAuthor)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.AuthorBooks)
                .HasForeignKey(x => x.idBook)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
