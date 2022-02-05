using System.Diagnostics.CodeAnalysis;
using BootTelegram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootTelegram.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class GroupMapping: IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(key => new {key.Id});

            builder.Property(prop => prop.Id)
                .HasColumnType("char(36)")
                .IsRequired();
            
            builder.Property(prop => prop.Description)
                .HasColumnType("varchar(200)")
                .IsRequired();
            
            builder.Property(prop => prop.CodeIndentifierGroup)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(prop => prop.CodeIndentifierGroupDestiny)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(prop => prop.FinalShippingType)
                .HasColumnType("char(1)")
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