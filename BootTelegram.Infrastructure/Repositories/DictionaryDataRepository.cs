using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;
using BootTelegram.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BootTelegram.Infrastructure.Repositories
{
    public class DictionaryDataRepository : IDictionaryDataRepository
    {
        private readonly DataContext _context;

        public DictionaryDataRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(DictionaryData entity)
        {
            _context.DictionaryData.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DictionaryData entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(DictionaryData entity)
        {
            _context.DictionaryData.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DictionaryData> GetById(Guid id)
        {
            return  await _context.DictionaryData
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DictionaryData>> GetAll()
        {
            return await _context.DictionaryData
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Dictionary<string, string>> GetDictionary()
        {
            var dataList = await GetAll();
            return dataList.ToDictionary(data => data.Key, data => data.Value);
        }
    };
}