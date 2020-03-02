using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Interfaces
{
    public interface IDefaultBussinessClass<TResource,TModel> where TResource: class
    {
        TResource Insert(TResource model);
        TResource Update(TResource model);
        void Delete(int id);
        TResource GetById(int Id);
        IEnumerable<TResource> GetAll();
    }
}
