using System;
using Common.DataTypes.Services.RentalService;
using Main.ResponseHost.Handlers;
using ServiceStack.Messaging.Redis;
using ServiceStack.Redis;

namespace Main.ResponseHost
{
    public class ResponseAppHost
    {
        public RedisMqServer Configure()
        {
            var redisFactory = new PooledRedisClientManager("localhost:6379");
            var mqServer = new RedisMqServer(redisFactory, retryCount: 2);

            mqServer.RegisterHandler<RentalServiceTestCommandResponse>(m => {
                new RentalServiceTestCommandResponseHandler().HandleMessage(m);
                return null;
            });

            mqServer.RegisterHandler<AnotherRentalServiceTestCommandResponse>(m => {
                new AnotherRentalServiceTestCommandResponseHandler().HandleMessage(m);
                return null;
            });

            return mqServer;
        }

        public void Start()
        {
            Configure().Start();
        }
    }
}
