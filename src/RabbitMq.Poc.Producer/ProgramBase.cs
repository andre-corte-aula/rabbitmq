using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Poc.Data.IoC;
using RabbitMq.Poc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Producer
{
    public abstract class ProgramBase
    {
        protected static readonly IProducerService _producerService;

        static ProgramBase()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            BootStrapper.RegisterServices(serviceCollection);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            _producerService = serviceProvider.GetService<IProducerService>();
        }
    }
}
