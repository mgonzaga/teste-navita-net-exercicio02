using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User
{
    public class ChangePasswordViewModel
    {
        public String UniqueId { get; set; }
        public int Id { get; set; }
        public String CurrentPassword { get; set; }
        public String NewPassword { get; set; }
        public String RetypeNewPassword { get; set; }
    }
}
