using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Data.Repositories;
using MGonzaga.IoC.NETCore.BusinessLayer.Impl;
using MGonzaga.IoC.NETCore.BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using MGonzaga.IoC.NETCore.Proxys.Email.Interfaces;
using MGonzaga.IoC.NETCore.Proxys.Email.Impl;
using Microsoft.EntityFrameworkCore;
using MGonzaga.IoC.NETCore.Data.Context;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace MGonzaga.IoC.NETCore.WebAPI.Initializers
{
    public class CasteWindsorInitializer : IWindsorInstaller
    {
        private readonly IConfiguration config;
        public CasteWindsorInitializer(IConfiguration configuration)
        {
            this.config = configuration;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            string connectionString = config["AppSettings:ConnectionString"];
            /*
                        container.Register(Classes.FromThisAssembly()
                                            .Where(Component.IsInSameNamespaceAs<King>())
                                            .WithService.DefaultInterfaces()
                                            .LifestyleTransient());
            */
            var dbOpt = new DbContextOptionsBuilder<SysDataBaseContext>();
            dbOpt.UseMySql(connectionString);

            container.Register(Component.For<IDbContext>().UsingFactoryMethod(c => new SysDataBaseContext(dbOpt.Options)));

            //Repositories Classes
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>());
            container.Register(Component.For<ILinksRepository>().ImplementedBy<LinksRepository>());

            // Business Classes
            container.Register(Component.For<IUserBusinessClass>().ImplementedBy<UserBusinessClass>());
            container.Register(Component.For<ILinksBusinessClass>().ImplementedBy<LinksBusinessClass>());

            // Proxies Classes
            container.Register(Component.For<IEmailSend>().ImplementedBy<EmailSend>());
        }
    }
}
