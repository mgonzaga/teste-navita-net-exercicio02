using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels;
using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.BusinessLayer.Interfaces
{
    public interface IUserBusinessClass : IDefaultBusinessClass<User,Domain.Models.User>
    {
        User LogIn(UserLoginViewModel login);
        IEnumerable<User> GetUsersbyFilterPagined(out int totalRecords, int page, int pageSize, string fullName, string email, bool? confirmedEmail);
        User GetByEmail(string email);
        User InsertUserWithEmailNotConfirmed(User user);
        string ForgotPassword(string email);
        string ConfirmEmail(ConfirmPasswordViewModel confirmEmail);
        string ChangePassword(int linkUniqueId, ChangePasswordViewModel value);
        string ChangeMyPassword(ChangePasswordViewModel value);
    }
}
