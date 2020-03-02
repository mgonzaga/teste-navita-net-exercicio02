using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User;
using System;
using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Interfaces
{
    public interface IUserBussinessClass : IDefaultBussinessClass<User,Domain.Models.User>
    {
        User LogIn(UserLoginViewModel login);
        IEnumerable<User> GetUsersbyFilterPagined(out int totalRecords, int page, int pageSize, string fullName, string email, bool? confirmedEmail);
        User GetByEmail(string email);
        User InsertUserWithEmailNotConfirmed(CreateNewUserViewModel user);
        string ForgotPassword(string email);
        string ConfirmEmail(ConfirmPasswordViewModel confirmEmail);
        void ChangePassword(Guid linkUniqueId, ChangePasswordViewModel value);
        string ChangeMyPassword(ChangePasswordViewModel value);
    }
}
