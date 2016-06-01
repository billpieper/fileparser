using System;
using System.Threading.Tasks;
using FileParser.Messaging;
using MassTransit;

namespace FileParser
{
    public class TestCommandConsumer : IConsumer<TestCommand>
    {
        public Task Consume(ConsumeContext<TestCommand> context)
        {
            Console.WriteLine("Hello from test consumer");

            return Task.FromResult(0);
        }
    }
}