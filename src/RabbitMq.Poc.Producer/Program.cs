using Microsoft.Extensions.Configuration;
using RabbitMq.Poc.Domain.Models;
using RabbitMQ.Client;
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
            Sender();

            Purge();
        }

        static void Sender()
        {
            int count = 0;

            string exchangeTypes = ExchangeType.Direct;

            QueueModel model = new QueueModel
            {
                AutoDelete = false,
                Durable = false,
                Exclusive = false,
                Exchange = $"ex-queue-{exchangeTypes}",
                Arguments = null,
                ExchangeTypes = exchangeTypes
            };

            _producerService.ExchangeCreate(model);

            do
            {
                Guid id = Guid.NewGuid();
                string queue = $"poc-fleury";

                model = new QueueModel
                {
                    Queue = queue,
                    AutoDelete = false,
                    Durable = false,
                    Exclusive = false,
                    Exchange = "",
                    ExchangeTypes = "",
                    RoutingKey = $"rk-{queue}",
                    Arguments = null,
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

                //_producerService.QueueBind(model);

                Console.WriteLine(model.Queue);
                count++;
            } while (count <= 100);
        }

        static void Purge()
        {
            int count = 0444;

            do
            {
                try
                {
                    string queue = $"poc-fleury";

                    _producerService.Purge(queue);

                    Console.WriteLine(queue);
                    count++;
                }
                catch (Exception exception)
                {

                }
            } while (count <= 100);
        }
    }
}
