using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces
{
    public interface IUserValidation
    {
        void Insert(CriarUsuarioViewModel newUser);
        void Update(AlterarUsuarioViewModel userData);
        void LogIn(LoginUsuarioViewModel login);
        void LogIn(LoginUsuarioViewModel login, User userData);
        void ForgotPassword(string email);
        void ChangePassword(Guid userUniqueId, AlterarSenhaViewModel value, User user);
    }
}
