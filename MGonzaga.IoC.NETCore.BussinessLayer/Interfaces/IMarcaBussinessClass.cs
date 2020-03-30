using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Interfaces
{
    public interface IMarcaBussinessClass : IDefaultBussinessClass<Marca, Domain.Models.Marca>
    {
        Marca Insert(CriarNovaMarcaViewModel marca);
        Marca Update(int id, AlterarMarcaViewModel marca);
    }
}
