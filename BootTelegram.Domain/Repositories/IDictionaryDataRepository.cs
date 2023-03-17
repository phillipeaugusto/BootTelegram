using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories.Contracts;

namespace BootTelegram.Domain.Repositories;

public interface IDictionaryDataRepository: IRepository<DictionaryData>
{
    public Task<Dictionary<string, string>> GetDictionary();
}