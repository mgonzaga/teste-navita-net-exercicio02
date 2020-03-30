using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User
{
    public class AlterarSenhaViewModel
    {
        public String CurrentPassword { get; set; }
        public String NewPassword { get; set; }
        public String RetypeNewPassword { get; set; }
    }
}
