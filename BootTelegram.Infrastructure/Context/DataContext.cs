using BootTelegram.Domain.Entities;
using BootTelegram.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BootTelegram.Infrastructure.Context;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfiguration(new GroupMapping())
            .ApplyConfiguration(new ReadingMapping())
            .ApplyConfiguration(new DictionaryDataMapping());

    }
    public DbSet<Group> Group { get; set; }
    public DbSet<Reading> Reading { get; set; }
    public DbSet<DictionaryData> DictionaryData { get; set; }

}