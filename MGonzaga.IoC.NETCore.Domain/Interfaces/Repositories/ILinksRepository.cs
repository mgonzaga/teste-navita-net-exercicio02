using MGonzaga.IoC.NETCore.Domain.Models;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories.Base;
using System;

namespace MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories
{
    public interface ILinksRepository : IWriteRepository<Links>
    {
        Links GetByUniqueId(Guid uniqueId);
        Links UpdateUsedLink(Links link);
    }
}
