using MGonzaga.IoC.NETCore.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.Domain.Models
{
    public class User : BaseModel
    {
        public String FullName { get; private set; }
        public String Email { get; private set; }
        public bool ConfirmedEmail { get; private set; }
        public String Password { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool Blocked { get; private set; }
        public DateTime? LoginLastDate { get; private set; }
        public int LoginAttempts { get; private set; }
        public Guid? UniqueId { get; private set; }
        public string Locale { get; private set; }
        public int OAuthProvider { get; private set; }
        public String OAuthUId { get; private set; }
        public String RolesNames { get; private set; }

        public void AlterFullName(String newFullName) => FullName = newFullName;
        public void AlterEmail(String newEmail) => Email = newEmail;
        public void AlterConfirmedEmail(bool newConfirmedEmail) => ConfirmedEmail = newConfirmedEmail;
        public void AlterPassword(String newPassword) => Password = newPassword;
        public void AlterCreateDate(DateTime newCreateDate) => CreateDate = newCreateDate;
        public void AlterBlocked(bool newBlocked) => Blocked = newBlocked;
        public void AlterLoginLastDate(DateTime? newLoginLastDate) => LoginLastDate = newLoginLastDate;
        public void AlterLoginAttempts(int newLoginAttempts) => LoginAttempts = newLoginAttempts;
        public void AlterUniqueId(Guid newUniqueId) => UniqueId = newUniqueId;
        public void AlterLocale(string newLocale) => Locale = newLocale;
        public void AlterOAuthProvider(int newOAuthProvider) => OAuthProvider = newOAuthProvider;
        public void AlterOAuthUId(string newOAuthUId) => OAuthUId = newOAuthUId;
        public void AlterRolesNames(string newRolesNames) => RolesNames = newRolesNames;

    }
}
