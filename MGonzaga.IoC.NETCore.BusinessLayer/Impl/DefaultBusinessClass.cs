using AutoMapper;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories.Base;
using MGonzaga.IoC.NETCore.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MGonzaga.IoC.NETCore.BusinessLayer.Impl
{
    public class DefaultBusinessClass<TResource, TModel> : IDefaultBusinessClass<TResource,TModel> where TResource: class where TModel : class
    {
        public readonly IWriteRepository<TModel> repository;
        private readonly IMapper _mapper;
        public DefaultBusinessClass(IWriteRepository<TModel> writeRepository, IMapper mapper)
        {
            this.repository = writeRepository;
            this._mapper = mapper;
        }

        public void Delete(int id)
        {
            var m = this.repository.GetById(id);
            if (m != null)
            {
                this.repository.Delete(m);
                this.repository.SaveChanges();
            }
            else
            {
                throw new ValidationException($"Record: {id} not found");
            }
        }

        public IEnumerable<TResource> GetAll()
        {
            var dbModels = this.repository.GetAll();
            return _mapper.Map<IEnumerable<TResource>>(dbModels);
        }

        public TResource GetById(int Id)
        {
            var dbModel = this.repository.GetById(Id);
            return _mapper.Map<TResource>(dbModel);
        }
        public TResource Insert(TResource model)
        {
            var dbModel = this.repository.Insert(_mapper.Map<TModel>(model));
            this.repository.SaveChanges();
            return _mapper.Map<TResource>(dbModel);
        }

        public TResource Update(TResource model)
        {
            var dbModel = this.repository.Update(_mapper.Map<TModel>(model));
            this.repository.SaveChanges();
            return _mapper.Map<TResource>(dbModel);
        }
    }
}
