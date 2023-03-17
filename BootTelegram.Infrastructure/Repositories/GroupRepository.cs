using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootTelegram.Domain.Constants;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;
using BootTelegram.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BootTelegram.Infrastructure.Repositories;

public class GroupRepository: IGroupRepository
{
    private readonly DataContext _context;

    public GroupRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(Group entity)
    {
        _context.Group.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Group entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Group entity)
    {
        _context.Group.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Group> GetById(Guid id)
    {
        return  await _context.Group
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Group>> GetAll()
    {
        return await _context.Group
            .AsNoTracking()
            .ToListAsync();
    }

        
    public async Task<List<Group>> GetActiveGroupsToRead()
    {
        return await _context.Group
            .AsNoTracking()
            .Where(x => x.Status == ApplicationConstants.StatusActive)
            .ToListAsync();
    }
}