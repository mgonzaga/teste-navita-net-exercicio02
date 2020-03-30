using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User
{
    public class CriarUsuarioViewModel
    {
        public String FullName { get; set; }
        public String Email { get; set; }
        public String ConfirmEmail { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
    }
}
