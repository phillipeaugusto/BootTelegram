using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;

namespace BootTelegram.Application.Services;

public class GroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
        
    public async Task<List<Group>> GetActiveGroupsToRead()
    {
        return await _groupRepository.GetActiveGroupsToRead();
    }
        
}