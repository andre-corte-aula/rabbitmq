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
                Guid id = Guid.NewGuid();
                string queue = $"Teste_{count}";

                QueueModel model = new QueueModel
                {
                    Queue = queue,
                    AutoDelete = false,
                    Durable = false,
                    Exclusive = false,
                    Exchange = id.ToString(),
                    RoutingKey = id.ToString(),
                    Arguments = null
                };

                string template = (count % 2 == 0) ?
                    @"C:\git\andre-corte-aula\rabbitmq\src\RabbitMq.Poc.Producer\Template\DeviceApp.html" :
                        @"C:\git\andre-corte-aula\rabbitmq\src\RabbitMq.Poc.Producer\Template\Education.html";
                MessageQueueModel message = new MessageQueueModel
                {
                    Id = id,
                    Type = $"promotional_{count}",
                    Content = File.ReadAllText(template)
                };
                _producerService.Sender(model, message);

                Console.WriteLine(model.Queue);
                count++;
            } while (count <= 100);
        }
    }
}
