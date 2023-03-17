using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;
using Moq;
using Xunit;
using static System.Threading.Tasks.Task;

namespace BootTelegram.Tests.Repositories;

public class GroupRepositoryTests
{
    private static Mock<IGroupRepository> _mockRepository = new Mock<IGroupRepository>();
    private static Group _group = new Group(Guid.NewGuid(), "xxxxx03", 003, 003, 'X');
    private static Group _groupOutput = new Group(Guid.NewGuid(), "xxxxx", 000, 001, 'X');
        
    private List<Group> _listOutput = new List<Group>
    {
        new Group(Guid.NewGuid(), "xxxxx03", 003, 003, 'X'),
        new Group(Guid.NewGuid(), "xxxxx04", 004, 004, 'X')
    };
        
    public GroupRepositoryTests()
    {
        _mockRepository.Setup(x => x.Create(It.IsAny<Group>()));
        _mockRepository.Setup(x => x.Delete(It.IsAny<Group>()));
        _mockRepository.Setup(x => x.Update(It.IsAny<Group>()));
            
    }
        
    [Fact]
    public async Task Given_to_an_valid_create()
    { 
        await _mockRepository.Object.Create(_group);
    }
        
    [Fact]
    public async Task Given_to_an_valid_delete()
    {
        await _mockRepository.Object.Delete(_group);
    }

    [Fact]
    public async Task Given_to_an_valid_update()
    {
        await _mockRepository.Object.Update(_group);
    }
        
    [Fact]
    public async Task Given_to_an_valid_getAll()
    { 
        _mockRepository.Setup(x => x.GetAll()).Returns(FromResult(_listOutput));
        var list = await _mockRepository.Object.GetAll();
        Assert.NotNull(list);
    }
        
    [Fact]
    public async Task Given_to_an_invalid_getAll()
    { 
        _mockRepository.Setup(x => x.GetAll()).Returns(FromResult<List<Group>>(null));
        var list = await _mockRepository.Object.GetAll();
        Assert.Null(list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_getById()
    { 
        _mockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_groupOutput));
        var obj = await _mockRepository.Object.GetById(new Guid());
        Assert.NotNull(obj);
    }
        
    [Fact]
    public async Task Given_to_an_invalid_getById()
    { 
        _mockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult<Group>(null));
        var obj = await _mockRepository.Object.GetById(new Guid());
        Assert.Null(obj);
    }
        
}