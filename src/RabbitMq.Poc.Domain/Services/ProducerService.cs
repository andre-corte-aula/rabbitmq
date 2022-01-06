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

        public void Sender(QueueModel model)
        {
            QueueDeclareOk result = _producerRepository.Queue(model);
            QueueDeclareOk resultS = _producerRepository.QueueDeclarePassive(model);
           // _producerRepository.QueueBind(model);
        }
    }
}
