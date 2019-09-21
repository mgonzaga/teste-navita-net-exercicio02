using MGonzaga.IoC.NETCore.Common.Resources.Models;
using System;

namespace MGonzaga.IoC.NETCore.BusinessLayer.Interfaces
{
    public interface ILinksBusinessClass : IDefaultBusinessClass<Common.Resources.Models.Links,Domain.Models.Links>
    {
        Links AddNewLink(int IdObject, Common.Resources.Enuns.AcceptedLinksTypeEnum LinkType);
        bool IsValidLink(Guid uniqueId);
        Links GetByUniqueId(Guid uniqueId);

    }
}
