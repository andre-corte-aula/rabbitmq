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
        private ConnectionFactory connectionFactory => new ConnectionFactory { Uri = new Uri("amqps://rigkxfeg:jf8QPsOXAbPG51lckmrPkoT3GQtyXPC8@jackal.rmq.cloudamqp.com/rigkxfeg") };

        protected QueueDeclareOk QueueDeclare(string queue, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
        {
            using (IConnection connection = connectionFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                return channel.QueueDeclare(queue, durable, exclusive, autoDelete, arguments);
            }
        }

        protected QueueDeclareOk QueueDeclarePassive(string queue)
        {
            using (IConnection connection = connectionFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                return channel.QueueDeclarePassive(queue);
            }
        }

        protected void QueueBind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            using (IConnection connection = connectionFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueBind(queue, exchange, routingKey, arguments);
            }
        }

        protected void Received(string queue, string exchange, string routingKey, IDictionary<string, object> arguments)
        {
            using (IConnection connection = connectionFactory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueBind(queue, exchange, routingKey, arguments);

                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ch, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    // copy or deserialise the payload
                    // and process the message
                    // ...

                    channel.BasicAck(ea.DeliveryTag, false);
                };
                // this consumer tag identifies the subscription
                // when it has to be cancelled
                string consumerTag = channel.BasicConsume(queue, false, consumer);
            }
        }
    }
}
