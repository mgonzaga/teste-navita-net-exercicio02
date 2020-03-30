using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User;
using System;
using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Interfaces
{
    public interface IUserBussinessClass : IDefaultBussinessClass<User,Domain.Models.User>
    {
        User LogIn(LoginUsuarioViewModel login);
        IEnumerable<User> GetUsersbyFilterPagined(out int totalRecords, int page, int pageSize, string fullName, string email);
        User GetByEmail(string email);
        User Insert(CriarUsuarioViewModel user);
        string ForgotPassword(string email);
        void ChangePassword(Guid userUniqueId, AlterarSenhaViewModel value);
        User Update(int userId,AlterarUsuarioViewModel userData);
    }
}
