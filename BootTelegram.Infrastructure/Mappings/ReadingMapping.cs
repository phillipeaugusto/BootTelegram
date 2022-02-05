using System.Diagnostics.CodeAnalysis;
using BootTelegram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootTelegram.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class ReadingMapping: IEntityTypeConfiguration<Reading>
    {
        public void Configure(EntityTypeBuilder<Reading> builder)
        {
            builder.HasKey(key => new {key.Id});

            builder.Property(prop => prop.Id)
                .HasColumnType("char(36)")
                .IsRequired();
            
            builder.Property(prop => prop.GroupId)
                .HasColumnType("char(36)")
                .IsRequired();
            
            builder.Property(prop => prop.ShippingType)
                .HasColumnType("char(1)")
                .IsRequired();
       
            builder.Property(prop => prop.DateTimeMessage)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(prop => prop.MessageId)
                .HasColumnType("varchar(50)");
        
            builder.Property(prop => prop.Message)
                .HasColumnType("varchar(4000)")
                .IsRequired();
            
            builder.HasOne(prop => prop.Group)
                .WithMany(x => x.Reading)
                .HasForeignKey(prop => prop.GroupId);
            
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