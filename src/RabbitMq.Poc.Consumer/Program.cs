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
                try
                {
                    string queue = $"poc-fleury";
                    string result = _cosumerService.Get(queue, true);

                    if (string.IsNullOrWhiteSpace(result))
                    {

                    }

                    Console.WriteLine(result);
                }
                catch (Exception exception)
                {

                }
                count++;

            } while (count <= 100);
        }
    }
}
