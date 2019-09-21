using AutoMapper;
namespace MGonzaga.IoC.NETCore.WebAPI.Initializers.Automapper.Entity
{
    public class LinksProfile : Profile
    {
        public LinksProfile()
        {
            CreateMap<Domain.Models.Links, Common.Resources.Models.Links>();
            CreateMap<Common.Resources.Models.Links, Domain.Models.Links>();
        }
    }
}
