using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Data.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Autor).HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.AnodePublicacao).IsRequired();
        }
    }
}
