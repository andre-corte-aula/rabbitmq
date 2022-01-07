using RabbitMq.Poc.Domain.Interfaces.Repository;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Data
{
    public class CosumerRepository : BaseContextRepository, ICosumerRepository
    {
        public string Get(string queue, bool autoAck)
        {
            BasicGetResult result = base.Get(queue, autoAck);
            return (result != null) ? Encoding.UTF8.GetString(result.Body.ToArray()) : string.Empty;
        }
    }
}
