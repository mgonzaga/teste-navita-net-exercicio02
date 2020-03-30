using MGonzaga.IoC.NETCore.Domain.Models;
using MGonzaga.IoC.NETCore.Domain.Impl.Repositories.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using System.Linq;
using System.Collections.Generic;
using MGonzaga.IoC.NETCore.Domain.Models.Filters;
using System;

namespace MGonzaga.IoC.NETCore.Data.Repositories
{
    public class UserRepository : WriteRepositoryImpl<User>, IUserRepository
    {
        private readonly IDbContext db;
        public UserRepository(IDbContext db) : base(db)
        {
            this.db = db;
        }
        public User GetByEmail(string email)
        {
            return db.Set<User>().WithEmail(email).FirstOrDefault();
        }
        public IEnumerable<User> GetUsersbyFilterPagined(out int totalRecords, int page, int pageSize, string fullName, string email)
        {
            var query = db.Set<User>()
                            .ContainsFullName(fullName)
                            .WithEmail(email);
            totalRecords = query.Count();
            var result = query
                            .Skip(page * pageSize)
                            .Take(pageSize)
                            .ToList();
            return result;
        }
        public override User Insert(User model)
        {
            model.AlterUniqueId(Guid.NewGuid());
            return base.Insert(model);
        }

        public User GetByUniqueId(Guid uniqueId)
        {
            return db.Set<User>().WithUniqueId(uniqueId).FirstOrDefault();
        }

    }
}
