using MGonzaga.IoC.NETCore.Common.Resources.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Proxys.Email.Interfaces
{
    public interface IEmailSend
    {
        void ForgotPassword(string mailTo, User userData);
        void EmailConfirmation(string mailTo, User userData);
    }
}
