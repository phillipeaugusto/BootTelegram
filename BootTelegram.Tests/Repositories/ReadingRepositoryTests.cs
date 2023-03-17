using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;
using Moq;
using Xunit;
using static System.DateTime;
using static System.Threading.Tasks.Task;

namespace BootTelegram.Tests.Repositories;

public class ReadingRepositoryTests
{
    private static Mock<IReadingRepository> _mockRepository = new Mock<IReadingRepository>();
    private static Reading _reading = new Reading(Guid.NewGuid(), Now, "message", "00", "X");
    private static Reading _readingOutput = new Reading(Guid.NewGuid(), Now, "message2", "01", "Z");

    private List<Reading> _listOutput = new List<Reading>
    {
        new Reading(Guid.NewGuid(), Now, "message03", "003", "Y"),
        new Reading(Guid.NewGuid(), Now, "message04", "004", "W")
    };
        
    public ReadingRepositoryTests()
    {
        _mockRepository.Setup(x => x.Create(It.IsAny<Reading>()));
        _mockRepository.Setup(x => x.Delete(It.IsAny<Reading>()));
        _mockRepository.Setup(x => x.Update(It.IsAny<Reading>()));
    }
        
    [Fact]
    public async Task Given_to_an_valid_create()
    { 
        await _mockRepository.Object.Create(_reading);
    }
        
    [Fact]
    public async Task Given_to_an_valid_delete()
    {
        await _mockRepository.Object.Delete(_reading);
    }

    [Fact]
    public async Task Given_to_an_valid_update()
    {
        await _mockRepository.Object.Update(_reading);
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
        _mockRepository.Setup(x => x.GetAll()).Returns(FromResult<List<Reading>>(null));
        var list = await _mockRepository.Object.GetAll();
        Assert.Null(list);
    }
        
    [Fact]
    public async Task Given_to_an_valid_getById()
    { 
        _mockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult(_readingOutput));
        var obj = await _mockRepository.Object.GetById(new Guid());
        Assert.NotNull(obj);
    }
        
    [Fact]
    public async Task Given_to_an_invalid_getById()
    { 
        _mockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(FromResult<Reading>(null));
        var obj = await _mockRepository.Object.GetById(new Guid());
        Assert.Null(obj);
    }
}