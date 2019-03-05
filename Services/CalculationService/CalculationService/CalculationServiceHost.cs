using System;
using CalculationService.Handlers;
using Common.DataTypes.Services.CalculationService;
using Funq;
using ServiceStack;
using ServiceStack.Messaging.Redis;
using ServiceStack.Redis;

namespace CalculationService
{
    public class CalculationServiceHost : AppSelfHostBase
    {
        public CalculationServiceHost() : base("Calculation Service", typeof(CalculationService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            base.Routes
                .Add<CalculatePriceCommand>("/calculation");

            var redisFactory = new PooledRedisClientManager("localhost:6379");
            container.Register<IRedisClientsManager>(redisFactory);

            var mqHost = new RedisMqServer(redisFactory, 2);
            var mqClient = mqHost.CreateMessageQueueClient();

            mqHost.RegisterHandler<CalculatePriceCommand>(m => {

                new CalculatePriceCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.Start();
        }
    }
}
