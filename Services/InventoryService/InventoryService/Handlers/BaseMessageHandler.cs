﻿using System;
using Common.Redis;
using InventoryService.Interfaces;
using ServiceStack.Messaging;

namespace InventoryService.Handlers
{
    public abstract class BaseMessageHandler : IHandleMessages
    {
        public RedisProxy rProxy => Redis.Get();

        public void HandleMessage(IMessage mqMessage, IMessageQueueClient client)
        {
            try
            {
                Console.WriteLine($"Starting handle message with id: {mqMessage.Id}");

                HandleThisMessage(mqMessage, client);

                Console.WriteLine($"Message with id: {mqMessage.Id} successfuly handled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while handling message with Id: {mqMessage.Id}");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public abstract void HandleThisMessage(IMessage mqMessage, IMessageQueueClient client);
    }
}
