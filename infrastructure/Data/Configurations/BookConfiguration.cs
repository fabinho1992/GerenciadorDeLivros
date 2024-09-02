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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Author).HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.ISBN).HasMaxLength(13)
                .IsRequired();
            builder.HasIndex(x => x.ISBN).IsUnique();
            builder.Property(x => x.YearOfPublication).IsRequired();
            builder.Property(x => x.StatusBook).HasConversion<string>()
                .IsRequired();
        }
    }
}
