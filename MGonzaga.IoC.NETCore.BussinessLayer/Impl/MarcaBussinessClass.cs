using AutoMapper;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Impl
{
    public class MarcaBussinessClass : DefaultBussinessClass<Common.Resources.Models.Marca, Domain.Models.Marca>, IMarcaBussinessClass
    {
        private readonly IMarcaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMarcaValidation _validation;
        public MarcaBussinessClass(IMarcaRepository repository, IMapper mapper, IMarcaValidation validation) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validation = validation;
        }

        public Common.Resources.Models.Marca Insert(CriarNovaMarcaViewModel marca)
        {
            _validation.Insert(marca);
            if (_repository.ExisteNomeMarca(marca.Nome, 0)) throw new ValidationException("Este nome de marca já esta cadastrado.");
            
            var model = _mapper.Map<Domain.Models.Marca>(marca);
            model = _repository.Insert(model);
            _repository.SaveChanges();
            
            return _mapper.Map<Common.Resources.Models.Marca>(model);
        }

        public Common.Resources.Models.Marca Update(int id, AlterarMarcaViewModel marca)
        {
            _validation.Update(marca);
            var model = _repository.GetById(id);
            if (_repository.ExisteNomeMarca(marca.Nome, id)) throw new ValidationException("Este nome de marca já esta cadastrado.");
            if (model == null) throw new ValidationException("Marca não encontrada");
            
            model.AlterNome(marca.Nome);
            _repository.Update(model);
            _repository.SaveChanges();

            return _mapper.Map<Common.Resources.Models.Marca>(model);
        }
    }
}
