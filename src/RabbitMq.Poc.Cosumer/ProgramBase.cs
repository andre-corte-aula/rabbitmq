using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Poc.Data.IoC;
using RabbitMq.Poc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMq.Poc.Cosumer
{
    public abstract class ProgramBase
    {
        protected static readonly ICosumerService _cosumerService;

        static ProgramBase()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            BootStrapper.RegisterServices(serviceCollection);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
             
            _cosumerService = serviceProvider.GetService<ICosumerService>();
        }
    }
}
