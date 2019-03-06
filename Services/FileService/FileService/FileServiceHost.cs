using Common.DataTypes.Services.FileService;
using FileService.Handlers;
using Funq;
using ServiceStack;
using ServiceStack.Messaging.Redis;
using ServiceStack.Redis;

namespace FileService
{
    public class FileServiceHost : AppSelfHostBase
    {
        public FileServiceHost() : base("File Service", typeof(FileService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            var redisFactory = new PooledRedisClientManager("localhost:6379");
            container.Register<IRedisClientsManager>(redisFactory);

            var mqHost = new RedisMqServer(redisFactory, 2);
            var mqClient = mqHost.CreateMessageQueueClient();

            mqHost.RegisterHandler<CreateInvoiceCommand>(m => {

                new CreateInvoiceCommandHandler().HandleMessage(m, mqClient);
                return base.ExecuteMessage(m);
            });

            mqHost.Start();
        }
    }
}
