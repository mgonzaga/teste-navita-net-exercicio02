using MGonzaga.IoC.NETCore.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.Domain.Models
{
    public class User : BaseModel
    {
        public String FullName { get; private set; }
        public String Email { get; private set; }
        public String Password { get; private set; }
        public Guid? UniqueId { get; private set; }

        public void AlterFullName(String newFullName) => FullName = newFullName;
        public void AlterEmail(String newEmail) => Email = newEmail;
        public void AlterPassword(String newPassword) => Password = newPassword;
        public void AlterUniqueId(Guid newUniqueId) => UniqueId = newUniqueId;

    }
}
