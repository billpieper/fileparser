using FileParser.Contracts;

namespace FileParser.Messaging
{
    public class TestCommand : IJob
    {
        public int JobId { get; set; }
    }
}