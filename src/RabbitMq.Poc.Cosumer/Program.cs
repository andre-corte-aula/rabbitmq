using System;

namespace RabbitMq.Poc.Cosumer
{
    internal class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            string result = _cosumerService.Queue();
        }
    }
}
