using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Poc.Domain.Interfaces;
using RabbitMq.Poc.Domain.Interfaces.Repository;
using RabbitMq.Poc.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Data.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ICosumerService, CosumerService>();
            services.AddTransient<IProducerService, ProducerService>();

            services.AddTransient<ICosumerRepository, CosumerRepository>();
            services.AddTransient<IProducerRepository, ProducerRepository>();
        }
    }
}
