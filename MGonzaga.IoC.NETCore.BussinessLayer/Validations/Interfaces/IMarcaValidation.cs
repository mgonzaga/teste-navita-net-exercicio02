using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces
{
    public interface IMarcaValidation
    {
        void Insert(CriarNovaMarcaViewModel marca);
        void Update(AlterarMarcaViewModel marca);
    }
}
