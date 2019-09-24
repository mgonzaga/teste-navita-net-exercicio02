using MGonzaga.IoC.NETCore.Common.Resources.Enuns;
using MGonzaga.IoC.NETCore.Domain.Models.Base;
using System;
namespace MGonzaga.IoC.NETCore.Domain.Models
{
    public class Links : BaseModel
    {
        public Guid UniqueId { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public AcceptedLinksTypeEnum Type { get; private set; }
        public DateTime CreateDate { get; private set; }
        public int ObjectId { get; private set; }

        public void AlterUniqueId(Guid newUniqueId) => UniqueId = newUniqueId;
        public void AlterExpireDate(DateTime newExpireDate) => ExpireDate = newExpireDate;
        public void AlterType(AcceptedLinksTypeEnum newType) => Type = newType;
        public void AlterCreateDate(DateTime newCreateDate) => CreateDate = newCreateDate;
        public void AlterObjectId(int newObjectId) => ObjectId = newObjectId;

    }
}
