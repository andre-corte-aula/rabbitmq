using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Data
{
    public abstract class BaseContextRepository
    {
        private IModel channel => new ConnectionFactory
        {
            Uri = new Uri(Environment.GetEnvironmentVariable("defaultConnectionStringRabbitMQFleury", EnvironmentVariableTarget.Machine))
        }.CreateConnection().CreateModel();

        protected void QueueBind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            channel.QueueBind(queue, exchange, routingKey, arguments);
        }

        protected void ExchangeDeclare(string exchange, string exchangeType)
        {
            channel.ExchangeDeclare(exchange, exchangeType);
        }

        protected void Queue(string queue, bool durable, bool exclusive, bool autoDelete, string message, IDictionary<string, object> arguments, string exchange = "")
        {
            channel.QueueDeclare(queue, durable, exclusive, autoDelete, arguments);
            byte[] body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange, queue, null, body);
        }

        protected void QueuePurge(string queue)
        {
            channel.QueuePurge(queue);
        }

        protected BasicGetResult Get(string queue, bool autoAck)
        {
            try
            {
                BasicGetResult getResult = channel.BasicGet(queue, autoAck);
                return getResult;
            }
            catch (Exception)
            {
                BasicGetResult getResult = channel.BasicGet(queue, false);
                return null;
            }
        }
    }
}
