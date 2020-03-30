#pragma warning disable
using AutoMapper;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;

namespace MGonzaga.IoC.NETCore.WebAPI.Initializers.Automapper.Entity
{
    public class MarcaProfile : Profile
    {
        public MarcaProfile()
        {
            CreateMap<Domain.Models.Marca, Common.Resources.Models.Marca>();
            CreateMap<Common.Resources.Models.Marca,Domain.Models.Marca>();
            CreateMap<CriarNovaMarcaViewModel, Domain.Models.Marca>();
        }
    }
}
