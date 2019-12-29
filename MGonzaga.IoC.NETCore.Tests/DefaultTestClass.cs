using AutoMapper;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Data.Repositories;
using MGonzaga.IoC.NETCore.BusinessLayer.Impl;
using MGonzaga.IoC.NETCore.BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using MGonzaga.IoC.NETCore.Proxys.Email.Interfaces;
using MGonzaga.IoC.NETCore.Proxys.Email.Impl;

namespace MGonzaga.IoC.NETCore.Tests
{
    public class DefaultTestClass
    {
        private readonly IMapper mapper;
        public DefaultTestClass()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Models.User, Common.Resources.Models.User>();
                cfg.CreateMap<Common.Resources.Models.User, Domain.Models.User>();
                cfg.CreateMap<Domain.Models.Links, Common.Resources.Models.Links>();
                cfg.CreateMap<Common.Resources.Models.Links, Domain.Models.Links>();

            });
            var config = InitConfiguration();
            var cnn = config["AppSettings:ConnectionString"];
            mapper = configuration.CreateMapper();
            //container = new WindsorContainer();
            //container.Register(Component.For<IDbContext>().UsingFactoryMethod(instance => new SysDataBaseContext(cnn)));
            //SysDataBaseContext

            //container.Register(Component.For<IMapper>().UsingFactoryMethod(instance => mapper));
            //container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>());
            //container.Register(Component.For<IUserBusinessClass>().ImplementedBy<UserBusinessClass>());
            //container.Register(Component.For<IEmailSend>().ImplementedBy<EmailSend>());
            //container.Register(Component.For<ILinksRepository>().ImplementedBy<LinksRepository>());
            //container.Register(Component.For<ILinksBusinessClass>().ImplementedBy<LinksBusinessClass>());
        }
        private IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json")
                .Build();
            return config;
        }


    }
}
