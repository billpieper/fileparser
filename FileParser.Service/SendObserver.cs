using System;
using System.Threading.Tasks;
using MassTransit;

namespace FileParser.Service
{
    public class SendObserver : ISendObserver
    {
        public Task PreSend<T>(SendContext<T> context) where T : class
        {
            return Task.FromResult(0);
        }

        public Task PostSend<T>(SendContext<T> context) where T : class
        {
            return Task.FromResult(0);
        }

        public Task SendFault<T>(SendContext<T> context, Exception exception) where T : class
        {
            return Task.FromResult(0);
        }
    }
}