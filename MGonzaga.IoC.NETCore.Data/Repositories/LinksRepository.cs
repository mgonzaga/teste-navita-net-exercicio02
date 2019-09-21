using MGonzaga.IoC.NETCore.Domain.Models;
using MGonzaga.IoC.NETCore.Domain.Impl.Repositories.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using System;
using System.Linq;

namespace MGonzaga.IoC.NETCore.Data.Repositories
{
    public class LinksRepository : WriteRepositoryImpl<Links>, ILinksRepository
    {
        private readonly IDbContext db;
        public LinksRepository(IDbContext db) : base(db)
        {
            this.db = db;
        }

        public Links GetByUniqueId(Guid uniqueId)
        {
            return db.Set<Links>().Where(t => t.UniqueId == uniqueId).FirstOrDefault();  
        }
    }
}
