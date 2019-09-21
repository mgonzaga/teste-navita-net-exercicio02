using MGonzaga.IoC.NETCore.Domain.Models.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;

namespace MGonzaga.IoC.NETCore.Domain.Impl.Repositories.Base
{
    public class WriteRepositoryImpl<T> : ReadRepositoryImpl<T>, IWriteRepository<T> where T : BaseModel
    {
        private readonly IDbContext db;
        public WriteRepositoryImpl(IDbContext db) : base(db)
        {
            this.db = db;
        }
        public void Delete(T model)
        {
            db.Set<T>().Remove(model);
        }

        public T Insert(T model)
        {
            return db.Set<T>().Add(model).Entity;
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public T Update(T model)
        {
            var m = db.Set<T>().Find(model.Id);
            db.Entry<T>(m).State = EntityState.Detached;
            return db.Set<T>().Update(model).Entity;
        }
        
    }
}
