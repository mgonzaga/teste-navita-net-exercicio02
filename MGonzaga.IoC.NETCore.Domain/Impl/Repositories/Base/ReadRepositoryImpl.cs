using MGonzaga.IoC.NETCore.Domain.Models.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;

namespace MGonzaga.IoC.NETCore.Domain.Impl.Repositories.Base
{
    public class ReadRepositoryImpl<T> : IReadRepository<T> where T: BaseModel
    {
        private readonly IDbContext db;
        public ReadRepositoryImpl(IDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return db.Set<T>().Where(_ => _.Id == id).FirstOrDefault();
        }
    }
}
