using System;
using Common.DataTypes.Services.InventoryService;
using Funq;
using InventoryService.Handlers;
using ServiceStack;
using ServiceStack.Messaging.Redis;
using ServiceStack.Redis;

namespace InventoryService
{
    public class InvenotryServiceHost : AppSelfHostBase
    {
        public InvenotryServiceHost() : base("Inventory Service", typeof(InvenotryService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            var redisFactory = new PooledRedisClientManager("localhost:6379");
            container.Register<IRedisClientsManager>(redisFactory);

            var mqHost = new RedisMqServer(redisFactory, 2);
            var mqClient = mqHost.CreateMessageQueueClient();

            mqHost.RegisterHandler<SetFilmAvailableCommand>(m => {

                new SetFilmAvailableCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.RegisterHandler<SetFilmUnavailableCommand>(m => {

                new SetFilmUnavailableCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.RegisterHandler<UpdateFilmCommand>(m => {

                new UpdateFilmCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.RegisterHandler<RemoveFilmCommand>(m => {

                new RemoveFilmCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.RegisterHandler<AddFilmCommand>(m => {

                new AddFilmCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.Start();
        }
    }
}
