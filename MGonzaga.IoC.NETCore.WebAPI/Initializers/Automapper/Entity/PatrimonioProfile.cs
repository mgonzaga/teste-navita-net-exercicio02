#pragma warning disable
using AutoMapper;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Patrimonio;

namespace MGonzaga.IoC.NETCore.WebAPI.Initializers.Automapper.Entity
{
    public class PatrimonioProfile : Profile
    {
        public PatrimonioProfile()
        {
            CreateMap<Domain.Models.Patrimonio, Common.Resources.Models.Patrimonio>();
            CreateMap<Common.Resources.Models.Patrimonio,Domain.Models.Patrimonio>();
            CreateMap<CriarNovoPatrimonioViewModel, Common.Resources.Models.Patrimonio>();
        }
    }
}
