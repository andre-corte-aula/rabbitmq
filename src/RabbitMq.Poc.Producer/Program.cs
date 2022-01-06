using Microsoft.Extensions.Configuration;
using RabbitMq.Poc.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

namespace RabbitMq.Poc.Producer
{
    internal class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            int count = 0;

            do
            {
                string id = Guid.NewGuid().ToString();
                string queue = $"Teste {id}";

                QueueModel model = new QueueModel
                {
                    Queue = queue,
                    AutoDelete = false,
                    Durable = true,
                    Exclusive = false,
                    Exchange = Guid.NewGuid().ToString(),
                    RoutingKey = Guid.NewGuid().ToString(),
                    Arguments = new Dictionary<string, object> { { id, queue }, { $"_{id}", Guid.NewGuid().ToString() } }
                };
                _producerService.Sender(model);

                Console.WriteLine(model.Queue);
                count++;
            } while (count <= 100);
        }
    }
}
