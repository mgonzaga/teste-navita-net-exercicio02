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
        public String Password { get;  set; }
        public Guid? UniqueId { get; set; }
    }
}
