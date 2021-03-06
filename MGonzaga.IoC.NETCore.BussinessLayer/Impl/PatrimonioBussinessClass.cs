﻿using AutoMapper;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Patrimonio;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Impl
{
    public class PatrimonioBussinessClass : DefaultBussinessClass<Common.Resources.Models.Patrimonio, Domain.Models.Patrimonio>, IPatrimonioBussinessClass
    {
        private readonly IPatrimonioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPatrimonioValidation _validation;
        public PatrimonioBussinessClass(IPatrimonioRepository repository, IMapper mapper, IPatrimonioValidation validation) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validation = validation;
        }

        public Patrimonio Insert(CriarNovoPatrimonioViewModel patrimonioViewModel)
        {
            _validation.Insert(patrimonioViewModel);
            
            var model = _mapper.Map<Domain.Models.Patrimonio>(patrimonioViewModel);
            model = _repository.Insert(model);
            _repository.SaveChanges();
            
            model.AlterNumeroTombo(model.Id);
            _repository.SaveChanges();

            return _mapper.Map<Common.Resources.Models.Patrimonio>(model);
        }

        public Patrimonio Update(int id, AlterarPatrimonioViewModel patrimonioViewModel)
        {
            var model = _validation.Update(id, patrimonioViewModel);
            model.AlterNome(patrimonioViewModel.Nome);
            model.AlterMarcaId(patrimonioViewModel.MarcaId);
            model.AlterDescricao(patrimonioViewModel.Descricao);
            _repository.Update(model);
            _repository.SaveChanges();
            return _mapper.Map<Patrimonio>(model);
        }
    }
}
