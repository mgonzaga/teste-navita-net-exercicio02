using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User
{
    public class ConfirmarSenhaViewModel
    {
        public Guid UniqueId { get; set; }
        public String EmailToConfirm { get; set; }
        public String ConfirmCode { get; set; }
    }
}
