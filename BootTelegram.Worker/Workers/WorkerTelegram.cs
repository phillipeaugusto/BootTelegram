using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using BootTelegram.Application.Services;
using BootTelegram.Domain.Entities;
using BootTelegram.Infrastructure.Services.Telegram;
using Microsoft.Extensions.Logging;
using TL;
using WTelegram;
using static System.String;

namespace BootTelegram.Workers
{
    public class WorkerTelegram
    {
        private ILogger _logger;
        private GroupService _groupService;
        private ReadingService _readingService;
        private MessageHandlingService _messageHandlingService;
        private TelegramConfig _telegramConfig;
        private List<Group> _listGroup;
        private Client _client;
        private User _myuser;
        
        public WorkerTelegram(ILogger logger, GroupService groupService, ReadingService readingService, MessageHandlingService messageHandlingService, TelegramConfig telegramConfig)
        {
            _logger = logger;
            _groupService = groupService;
            _readingService = readingService;
            _telegramConfig = telegramConfig;
            _messageHandlingService = messageHandlingService;
        }

        private async Task GetGroupRead()
        { 
            _logger.LogInformation("Getting Contact Groups - {RequestTime} ", DateTime.Now);
            _listGroup = await _groupService.GetActiveGroupsToRead();
        }
       
        private async Task ConnectTelegramAsync()
        {
            _logger.LogInformation("Connecting on Telegram- {RequestTime} ", DateTime.Now);
            _client = new Client(_telegramConfig.Config);
            await _client.ConnectAsync();
            _logger.LogInformation("Logging in to Telegram - {RequestTime} ", DateTime.Now);
            _myuser = await _client.LoginUserIfNeeded();
            _logger.LogInformation("Starting Message Monitoring - {RequestTime} ", DateTime.Now);
            _client.Update += ListenUpdateMessagesAsync;
        }

        public async Task ExecuteAsync()
        {
            await GetGroupRead();
            await ConnectTelegramAsync();
        }
        
        private async void ListenUpdateMessagesAsync(IObject arg)
        { 
            if (arg is not UpdatesBase updates) return;

            foreach (var update in updates.UpdateList)
            {
                switch (update)
                {
                    case UpdateNewChannelMessage unc: await ProcessMessage(unc.message); break; 
                    case UpdateNewMessage unm: await ProcessMessage(unm.message); break;
                    default: Console.WriteLine(update.GetType().Name); break;
                }
            }
        }

        private async Task SaveData(Reading reading)
        {
            _logger.LogInformation("Saving Data in Base .... - {RequestTime} ", DateTime.Now);
            await _readingService.SaveData(reading);
        }

        private string ReturnShippingType(long id)
        {
            return _myuser.id == id ? "S" : "R";
        }

        private async Task<long> ReturnAccessHashFromChat(long chatId)
        {
            var chats = await _client.Messages_GetAllChats(null);
            return ((Channel) chats.chats[chatId]).access_hash;
        }
        private async Task ProcessMessage(MessageBase msg)
        {
            InputPeer peerUser;
            var group = _listGroup.FirstOrDefault(x => x.CodeIndentifierGroup == msg.Peer.ID);

            if ((group is null) || (msg is not Message message)) return;
            if (message.message == Empty) return;
            
            
            if (group.FinalShippingType == 'G')
                peerUser = new InputPeerChannel {access_hash = await ReturnAccessHashFromChat(group.CodeIndentifierGroupDestiny), channel_id = group.CodeIndentifierGroupDestiny};
            else
                peerUser = new InputPeerUser {user_id = group.CodeIndentifierGroupDestiny};

            _logger.LogInformation("Adjusting Message .... - {RequestTime} ", DateTime.Now);
            var msgAdjust = await _messageHandlingService.AdjustMessage(message.message);
            _logger.LogInformation("Sending Message .... - {RequestTime} ", DateTime.Now);
            await _client.SendMessageAsync(peerUser, msgAdjust);
            
            await SaveData(new Reading {
                GroupId = group.Id, 
                Message = message.message, 
                DateTimeMessage = message.date, 
                MessageId = message.id.ToString(), 
                ShippingType = ReturnShippingType(msg.Peer.ID)}
            );
            
            _logger.LogInformation("Message Sent and Saved Successfully .... - {RequestTime} ", DateTime.Now);
        }
    }
}