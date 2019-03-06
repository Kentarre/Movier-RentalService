using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Redis;
using Main.Interfaces;
using ServiceStack.Messaging;

namespace Main.ResponseHost
{
    public abstract class BaseMessageHandler: IHandleMessages
    {
        public RedisProxy rProxy => Redis.Get();

        public void HandleMessage(IMessage mqMessage)
        {
            try
            {
                Console.WriteLine($"Starting handle message with id: {mqMessage.Id}");

                HandleThisMessage(mqMessage);

                Console.WriteLine($"Message with id: {mqMessage.Id} successfuly handled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured while handling message with Id: {mqMessage.Id}");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public abstract void HandleThisMessage(IMessage mqMessage);
    }
}
