using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories.Base;
using MGonzaga.IoC.NETCore.Domain.Models;
using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IWriteRepository<User>
    {
        User GetByEmail(string email);
        IEnumerable<User> GetUsersbyFilterPagined(out int totalRecords, int page, int pageSize, string fullName, string email, bool? confirmedEmail);
    }
}
