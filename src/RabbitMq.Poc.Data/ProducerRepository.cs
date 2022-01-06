using RabbitMq.Poc.Domain.Interfaces.Repository;
using RabbitMq.Poc.Domain.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Data
{
    public class ProducerRepository : BaseContextRepository, IProducerRepository
    {
        public QueueDeclareOk Queue(QueueModel model)
        {
            return base.QueueDeclare(model.Queue, model.Durable, model.Exclusive, model.AutoDelete, model.Arguments);
        }

        public QueueDeclareOk QueueDeclarePassive(QueueModel model)
        {
            return base.QueueDeclarePassive(model.Queue);
        }

        public void QueueBind(QueueModel model)
        {
            base.QueueBind(model.Queue, model.Exchange, model.RoutingKey, model.Arguments);
        }
    }
}
