using System.Collections.Generic;
using BootTelegram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootTelegram.Infrastructure.Mappings
{
    public class DictionaryDataMapping: IEntityTypeConfiguration<DictionaryData>
    {
        public void Configure(EntityTypeBuilder<DictionaryData> builder)
        {
            builder.HasKey(key => new {key.Id});

            builder.Property(prop => prop.Id)
                .HasColumnType("char(36)")
                .IsRequired();
            
            builder.Property(prop => prop.Key)
                .HasColumnType("varchar(200)")
                .IsRequired();
            
            builder.Property(prop => prop.Value)
                .HasColumnType("varchar(200)")
                .IsRequired();
            
            builder.Property(prop => prop.Status)
                .HasColumnType("char(1)")
                .IsRequired();
          
            builder.Property(prop => prop.DateChange)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(prop => prop.DateCreation)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}