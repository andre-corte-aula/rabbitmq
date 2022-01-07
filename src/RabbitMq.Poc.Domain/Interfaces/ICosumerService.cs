using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Domain.Interfaces
{
    public interface ICosumerService
    {
        string Get(string queue, bool autoAck);
    }
}
