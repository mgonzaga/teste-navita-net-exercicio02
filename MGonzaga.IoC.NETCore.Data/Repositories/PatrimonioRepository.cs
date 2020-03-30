using MGonzaga.IoC.NETCore.Domain.Impl.Repositories.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Data.Repositories
{
    public class PatrimonioRepository : WriteRepositoryImpl<Patrimonio>, IPatrimonioRepository
    {
        private readonly IDbContext db;
        public PatrimonioRepository(IDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
