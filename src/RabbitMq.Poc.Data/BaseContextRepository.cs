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
            Uri = new Uri(Environment.GetEnvironmentVariable("defaultConnectionStringRabbitMQFleury"))
        }.CreateConnection().CreateModel();

        protected void Queue(string queue, bool durable, bool exclusive, bool autoDelete, string message, IDictionary<string, object> arguments, string exchange = "")
        {
            // using (IConnection connection = connectionFactory.CreateConnection())
            //using (IModel channel = connection.CreateModel())
            //{
            channel.QueueDeclare(queue, durable, exclusive, autoDelete, arguments);
            byte[] body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange, queue, null, body);
            // }
            // }
        }

        protected BasicGetResult Get(string queue, bool autoAck)
        {
            // using (IConnection connection = connectionFactory.CreateConnection())
            //using (IModel channel = connection.CreateModel())
            //{
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
            // }
        }
    }
}
