using MGonzaga.IoC.NETCore.Common.Resources.Enuns;
using System;
namespace MGonzaga.IoC.NETCore.Common.Resources.Models
{
    public class Links
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public DateTime ExpireDate { get; set; }
        public AcceptedLinksTypeEnum Type { get; set; }
        public DateTime CreateDate { get; set; }
        public int ObjectId { get;  set; }
        public bool UsedLink { get;  set; }
    }
}
