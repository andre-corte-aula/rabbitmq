using System;

namespace RabbitMq.Poc.Consumer
{
    internal class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            int count = 0;

            do
            {
                string queue = $"Teste_{count}";
                string result = _cosumerService.Get(queue, true);

                Console.WriteLine(result);
                count++;
            } while (count <= 100);
        }
    }
}
