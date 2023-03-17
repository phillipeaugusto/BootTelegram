using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Application.Services;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;
using Moq;
using Xunit;
using static System.DateTime;

namespace BootTelegram.Tests.Services;

public class ReadingServiceTests
{
    private static Mock<IReadingRepository>  _mockRepository = new Mock<IReadingRepository>();
    private static Reading _reading = new Reading(Guid.NewGuid(), Now, "message", "00", "X");
    private readonly List<Reading> _list = new()
    {
        new Reading(Guid.NewGuid(), Now, "message01", "001", "X"),
        new Reading(Guid.NewGuid(), Now, "message02", "002", "Z")
    };
       
    [Fact]
    private async Task Given_to_an_valid_SaveDataAsync()
    {
        _mockRepository.Setup(x => x.Create(It.IsAny<Reading>()));
        var service = new ReadingService(_mockRepository.Object);
        await service.SaveData(_reading);
    }
}