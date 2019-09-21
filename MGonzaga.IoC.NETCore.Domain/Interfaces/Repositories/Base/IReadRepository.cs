using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories.Base
{
    public interface IReadRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
