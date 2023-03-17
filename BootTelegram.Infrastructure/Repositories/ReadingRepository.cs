

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;
using BootTelegram.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BootTelegram.Infrastructure.Repositories;

public class ReadingRepository: IReadingRepository
{
    private readonly DataContext _context;

    public ReadingRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(Reading entity)
    {
        _context.Reading.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Reading entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Reading entity)
    {
        _context.Reading.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Reading> GetById(Guid id)
    {
        return  await _context.Reading
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Reading>> GetAll()
    {
        return await _context.Reading
            .AsNoTracking()
            .ToListAsync();
    }
}