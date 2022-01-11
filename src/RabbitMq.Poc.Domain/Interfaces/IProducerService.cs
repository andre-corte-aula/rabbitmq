using RabbitMq.Poc.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Domain.Interfaces
{
    public interface IProducerService
    {
        void QueueBind(QueueModel model);
        void ExchangeCreate(QueueModel model);
        void Purge(string queue);
        void Sender(QueueModel model, MessageQueueModel message);
    }
}
