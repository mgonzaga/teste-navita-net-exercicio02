using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels
{
    public class ConfirmPasswordViewModel
    {
        public Guid UniqueId { get; set; }
        public String EmailToConfirm { get; set; }
        public String ConfirmCode { get; set; }
    }
}
