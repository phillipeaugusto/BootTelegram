using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using BootTelegram.Domain.Repositories;

namespace BootTelegram.Application.Services
{
    public class MessageHandlingService
    {
        private readonly IDictionaryDataRepository _dictionaryDataRepository;

        public MessageHandlingService(IDictionaryDataRepository dictionaryDataRepository)
        { 
            _dictionaryDataRepository = dictionaryDataRepository;
        }
        
        public async Task<string> AdjustMessage(string message)
        {
            var dataDictionary = await _dictionaryDataRepository.GetDictionary();

            foreach (var (key, value) in dataDictionary) 
                message = message.Replace(key, value, true, CultureInfo.InvariantCulture);
                
            return message;
        }
    }
}