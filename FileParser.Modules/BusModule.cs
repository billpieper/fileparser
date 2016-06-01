using System;
using MassTransit;
using Ninject.Modules;

namespace FileParser.Modules
{
    public class BusModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBusControl>().ToMethod(ctx => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Durable = true;

                cfg.UseRetry(Retry.Interval(5, TimeSpan.FromSeconds(60)));

                var host = cfg.Host(new Uri("http://localhost:15672/"), h =>
                {
                    h.Username("TestAppUser");
                    h.Password("TestAppUser");
                });

                cfg.ReceiveEndpoint(host, "TestQueue", e => e.Consumer<TestCommandConsumer>());

            })).InSingletonScope();
        }
    }
}