﻿using RabbitMq.Poc.Domain.Interfaces.Repository;
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
        public void Queue(QueueModel model, string message)
        {
            base.Queue(model.Queue, model.Durable, model.Exclusive, model.AutoDelete, message, model.Arguments);
        }
    }
}
