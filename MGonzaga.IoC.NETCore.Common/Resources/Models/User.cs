using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.Models
{
    public class User
    {
        public int Id { get; set; }
        public String FullName { get;  set; }
        public String Email { get;  set; }
        public bool ConfirmedEmail { get;  set; }
        public String Password { get;  set; }
        public DateTime CreateDate { get;  set; }
        public bool Blocked { get; set; }
        public DateTime LoginLastDate { get; set; }
        public int LoginAttempts { get; set; }
        public Guid? UniqueId { get; set; }
        public string Locale { get; set; }
        public int OAuthProvider { get; set; }
        public String OAuthUId { get; set; }
        public String RolesNames { get; set; }
    }
}
