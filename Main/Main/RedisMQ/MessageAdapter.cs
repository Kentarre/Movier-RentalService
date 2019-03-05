using System;
using ServiceStack.Messaging;
using ServiceStack.Redis;

namespace Main.RedisMQ
{
    public static class MessageAdapter
    {
        private static readonly RedisManagerPool _redisManager;

        static MessageAdapter()
        {
            _redisManager = new RedisManagerPool("localhost:6379");
        }

        public static void SendMessage<T>(T message)
        {
            using(var cli = new RedisMessageProducer(_redisManager))
            {
                cli.Publish(message);
            }
        }
    }
}
