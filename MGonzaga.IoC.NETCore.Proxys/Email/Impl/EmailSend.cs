using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Proxys.Email.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Proxys.Email.Impl
{
    public class EmailSend : IEmailSend
    {
        public void EmailConfirmation(string mailTo, User userData, Links links)
        {
        }
        public void ForgotPassword(string mailTo, User userData, Links links)
        {
        }
    }
}
