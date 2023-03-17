using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Application.Services;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;
using Moq;
using Xunit;
using static System.Threading.Tasks.Task;

namespace BootTelegram.Tests.Services;

public class GroupServiceTests
{
    private static Mock<IGroupRepository>  _mockRepository = new Mock<IGroupRepository>();
    private readonly List<Group> _list = new()
    {
        new Group(Guid.NewGuid(), "xxxxx01", 001, 001, 'X'),
        new Group(Guid.NewGuid(), "xxxxx02", 002, 002, 'X')
    };
        
       
    [Fact]
    public async Task Given_to_an_valid_GetActiveGroupsToRead()
    {
        _mockRepository.Setup(x => x.GetActiveGroupsToRead()).Returns(FromResult(_list));
        var service = new GroupService(_mockRepository.Object);
        var result = await service.GetActiveGroupsToRead();
        Assert.True(result is not null);
    }
}