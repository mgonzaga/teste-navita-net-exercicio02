using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using MGonzaga.IoC.NETCore.WebAPI.Initializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace MGonzaga.IoC.NETCore.WebAPI
{
    public class ServiceResolver
    {
        private static WindsorContainer container;
        private static IServiceProvider serviceProvider;

        public ServiceResolver(IServiceCollection services, IConfiguration configuration)
        {
            container = new WindsorContainer();
            container.Install(new CasteWindsorInitializer(configuration));
            serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
}
