#pragma warning disable
using AutoMapper;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User;

namespace MGonzaga.IoC.NETCore.WebAPI.Initializers.Automapper.Entity
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Models.User, Common.Resources.Models.User>();
            CreateMap<Common.Resources.Models.User,Domain.Models.User>();
            CreateMap<CriarUsuarioViewModel, Common.Resources.Models.User>();
        }
    }
}
