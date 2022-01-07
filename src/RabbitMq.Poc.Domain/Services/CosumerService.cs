using RabbitMq.Poc.Domain.Interfaces;
using RabbitMq.Poc.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Domain.Services
{
    public class CosumerService : ICosumerService
    {
        private readonly ICosumerRepository _cosumerRepository;

        public CosumerService(ICosumerRepository cosumerRepository)
        {
            _cosumerRepository = cosumerRepository;
        }

        public string Get(string queue, bool autoAck)
        {
            return _cosumerRepository.Get(queue, autoAck);
        }
    }
}
