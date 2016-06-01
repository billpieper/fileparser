using FileParser.Messaging;
using MassTransit;
using Topshelf;

namespace FileParser.Service
{
    public class Startup : ServiceControl
    {
        private readonly IBusControl _bus;

        public Startup(IBusControl bus)
        {
            _bus = bus;
        }

        public bool Start(HostControl hostControl)
        {
            _bus.ConnectConsumeObserver(new ConsumeObserver());

            _bus.ConnectSendObserver(new SendObserver());

            _bus.Start();

            _bus.Publish(new TestCommand{ JobId = 1 });

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _bus.Stop();

            return true;
        }
    }
}