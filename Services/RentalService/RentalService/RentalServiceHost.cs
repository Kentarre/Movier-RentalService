using System;
using Common.DataTypes.Services.RentalService;
using Funq;
using RentalService.Handlers;
using ServiceStack;
using ServiceStack.Messaging;
using ServiceStack.Messaging.Redis;
using ServiceStack.Redis;

namespace RentalService
{
    public class RentalServiceHost : AppSelfHostBase
    {
        public RentalServiceHost() : base("Rental Service", typeof(RentalService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            base.Routes
                .Add<RentalServiceTestCommand>("/rttest");

            var redisFactory = new PooledRedisClientManager("localhost:6379");
            container.Register<IRedisClientsManager>(redisFactory);

            var mqHost = new RedisMqServer(redisFactory, 2);
            var mqClient = mqHost.CreateMessageQueueClient();

            mqHost.RegisterHandler<RentalServiceTestCommand>(m => {

                new RentalServiceTestCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.RegisterHandler<AnotherRentalServiceTestCommand>(m => {

                new AnotherRetntalServiceTestCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.RegisterHandler<StartRentalCommand>(m => {
                
                new StartRentalCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.RegisterHandler<StopRentalCommand>(m => {

                new StopRentalCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.Start();
        }
    }
}
