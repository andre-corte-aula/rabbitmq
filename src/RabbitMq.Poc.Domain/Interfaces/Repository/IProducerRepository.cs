using RabbitMq.Poc.Domain.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Domain.Interfaces.Repository
{
    public interface IProducerRepository
    {
        void QueueBind(QueueModel model);
        void ExchangeDeclare(QueueModel model);
        void Purge(string queue);
        void Queue(QueueModel model, string message);
    }
}
