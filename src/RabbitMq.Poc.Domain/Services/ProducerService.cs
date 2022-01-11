using Newtonsoft.Json;
using RabbitMq.Poc.Domain.Interfaces;
using RabbitMq.Poc.Domain.Interfaces.Repository;
using RabbitMq.Poc.Domain.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Domain.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public void Purge(string queue)
        {
            _producerRepository.Purge(queue);
        }

        public void ExchangeCreate(QueueModel model)
        {
            _producerRepository.ExchangeDeclare(model);
        }
        
        public void QueueBind(QueueModel model)
        {
            _producerRepository.QueueBind(model);
        }

        public void Sender(QueueModel model, MessageQueueModel message)
        {
            string messageValue = JsonConvert.SerializeObject(message, Formatting.Indented);
            _producerRepository.Queue(model, messageValue);
        }
    }
}
