using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Pipeline;

namespace FileParser.Service
{
    public class ConsumeObserver : IConsumeObserver
    {
        public Task PreConsume<T>(ConsumeContext<T> context) where T : class
        {
            return Task.FromResult(0);
        }

        public Task PostConsume<T>(ConsumeContext<T> context) where T : class
        {
            return Task.FromResult(0);
        }

        public Task ConsumeFault<T>(ConsumeContext<T> context, Exception exception) where T : class
        {
            Console.WriteLine(exception);

            return Task.FromResult(0);
        }
    }
}