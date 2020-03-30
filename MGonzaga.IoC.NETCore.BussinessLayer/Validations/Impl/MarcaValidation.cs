using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Validations.Impl
{
    public class MarcaValidation : IMarcaValidation
    {
        public void Insert(CriarNovaMarcaViewModel marca)
        {
            if (String.IsNullOrEmpty(marca.Nome)) throw new ValidationException("O Nome da marca é obrigatório");
            if (marca.Nome.Length > 50) throw new ValidationException("O Nome da marca deve conter no máximo 50 caracteres");
        }

        public void Update(AlterarMarcaViewModel marca)
        {
            if (String.IsNullOrEmpty(marca.Nome)) throw new ValidationException("O Nome da marca é obrigatório");
            if (marca.Nome.Length > 50) throw new ValidationException("O Nome da marca deve conter no máximo 50 caracteres");
        }
    }
}
