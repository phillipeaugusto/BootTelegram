using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootTelegram.Domain.Entities;
using BootTelegram.Domain.Repositories;

namespace BootTelegram.Application.Services;

public class ReadingService
{
    private readonly IReadingRepository _readingRepository;

    public ReadingService(IReadingRepository readingRepository)
    {
        _readingRepository = readingRepository;
    }
        
    public async Task SaveData(Reading reading)
    { 
        await _readingRepository.Create(reading);
    }
}