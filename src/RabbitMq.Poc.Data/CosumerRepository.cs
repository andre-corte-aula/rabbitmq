using RabbitMq.Poc.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Data
{
    public class CosumerRepository : BaseContextRepository, ICosumerRepository
    {
        public string Queue()
        {
            throw new NotImplementedException();
        }
    }
}
