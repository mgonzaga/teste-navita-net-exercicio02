using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Validations.Impl
{
    public class MarcaValidation : IMarcaValidation
    {
        private readonly IMarcaRepository _marcaRepository;
        public MarcaValidation(IMarcaRepository marcaRepository)
        {
            this._marcaRepository = marcaRepository;
        }
        public void Insert(CriarNovaMarcaViewModel marca)
        {
            if (String.IsNullOrEmpty(marca.Nome)) throw new ValidationException("O Nome da marca é obrigatório");
            if (marca.Nome.Length > 50) throw new ValidationException("O Nome da marca deve conter no máximo 50 caracteres");
            if (_marcaRepository.ExisteNomeMarca(marca.Nome, -1)) throw new ValidationException("Este nome de marca já esta cadastrado.");
        }

        public Domain.Models.Marca Update(int marcaId, AlterarMarcaViewModel marca)
        {
            if (String.IsNullOrEmpty(marca.Nome)) throw new ValidationException("O Nome da marca é obrigatório");
            if (marca.Nome.Length > 50) throw new ValidationException("O Nome da marca deve conter no máximo 50 caracteres");
            if (_marcaRepository.ExisteNomeMarca(marca.Nome, marcaId)) throw new ValidationException("Este nome de marca já esta cadastrado.");
            var model = _marcaRepository.GetById(marcaId);
            if (model == null) throw new ValidationException(System.Net.HttpStatusCode.NotFound,"Marca não encontrada");
            return model;
        }
    }
}
