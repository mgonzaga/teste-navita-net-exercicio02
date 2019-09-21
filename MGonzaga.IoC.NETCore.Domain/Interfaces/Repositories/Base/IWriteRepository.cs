using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories.Base
{
    public interface IWriteRepository<T> : IReadRepository<T> where T : class
    {
        T Insert(T model);
        T Update(T model);
        void Delete(T model);
        int SaveChanges();
    }
}
