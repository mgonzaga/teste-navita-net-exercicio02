using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Patrimonio;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Interfaces
{
    public interface IPatrimonioBussinessClass : IDefaultBussinessClass<Patrimonio, Domain.Models.Patrimonio>
    {
        Patrimonio Insert(CriarNovoPatrimonioViewModel patrimonioViewModel);
        Patrimonio Update(int id, AlterarPatrimonioViewModel patrimonioViewModel);
    }
}
