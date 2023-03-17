using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories.Contracts;

namespace BootTelegram.Domain.Repositories;

public interface IGroupRepository: IRepository<Group>
{
    public Task<List<Group>> GetActiveGroupsToRead();
}