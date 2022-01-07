﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Domain.Models
{
    public class MessageQueueModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
    }
}
