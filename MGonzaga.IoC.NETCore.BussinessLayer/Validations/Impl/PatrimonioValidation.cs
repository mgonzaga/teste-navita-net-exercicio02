using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Patrimonio;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Validations.Impl
{
    public class PatrimonioValidation : IPatrimonioValidation
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IMarcaRepository _marcaRepository;
        public PatrimonioValidation(IPatrimonioRepository patrimonioRepository, IMarcaRepository marcaRepository)
        {
            this._patrimonioRepository = patrimonioRepository;
            this._marcaRepository = marcaRepository;
        }
        public void Insert(CriarNovoPatrimonioViewModel patrimonioViewModel)
        {

            if (String.IsNullOrEmpty(patrimonioViewModel.Nome)) throw new ValidationException("O Nome do patrimônio é obrigatório");
            if (patrimonioViewModel.Nome.Length > 100) throw new ValidationException("O Nome do patrimônio deve conter no máximo 100 caracteres");
            if (patrimonioViewModel.Descricao.Length > 1000) throw new ValidationException("A descrição do patrimônio deve conter no máximo 100 caracteres");
            if (!_marcaRepository.ExisteMarcaPorId(patrimonioViewModel.MarcaId))
            {
                throw new ValidationException($"Marca Id:{patrimonioViewModel.MarcaId} não encontrada");
            }
        }

        public Domain.Models.Patrimonio Update(int id, AlterarPatrimonioViewModel patrimonioViewModel)
        {
            if (String.IsNullOrEmpty(patrimonioViewModel.Nome)) throw new ValidationException("O Nome do patrimônio é obrigatório");
            if (String.IsNullOrEmpty(patrimonioViewModel.Descricao)) throw new ValidationException("A Descrição do patrimônio é obrigatório");
            if (patrimonioViewModel.Nome.Length > 100) throw new ValidationException("O Nome do patrimônio deve conter no máximo 100 caracteres");
            if (patrimonioViewModel.Descricao.Length > 1000) throw new ValidationException("A descrição do patrimônio deve conter no máximo 100 caracteres");
            if (!_marcaRepository.ExisteMarcaPorId(patrimonioViewModel.MarcaId))
            {
                throw new ValidationException($"Marca Id:{patrimonioViewModel.MarcaId} não encontrada");
            }
            var model = _patrimonioRepository.GetById(id); 
            if (model == null) throw new ValidationException(System.Net.HttpStatusCode.NotFound, $"Patrimônio:{id} não encontrado");
            return model;
        }
    }
}
