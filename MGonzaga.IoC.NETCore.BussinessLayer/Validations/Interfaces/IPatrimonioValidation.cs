using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Patrimonio;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces
{
    public interface IPatrimonioValidation
    {
        void Insert(CriarNovoPatrimonioViewModel patrimonioViewModel);
        void Update(AlterarPatrimonioViewModel patrimonioViewModel);
    }
}
