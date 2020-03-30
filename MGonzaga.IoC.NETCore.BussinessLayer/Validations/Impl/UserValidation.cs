using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User;
using System;
using System.Collections.Generic;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using System.Net;
using System.Text;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Validations.Impl
{
    public class UserValidation : IUserValidation
    {
        public void Insert(CriarUsuarioViewModel newUser)
        {
            if (newUser.FullName.Length > 100) throw new ValidationException("O Nome do usuário deve conter no máximo 100 caracteres");
            if (newUser.Email.Length > 200) throw new ValidationException("O E-mail deve conter no máximo 200 caracteres");
            if (newUser.Password.Length > 10) throw new ValidationException("A senha deve conter no máximo 10 caracteres");

            if (String.IsNullOrEmpty(newUser.Email)) throw new ValidationException("Informe um endereço de e-mail");
            if (String.IsNullOrEmpty(newUser.Password)) throw new ValidationException("Informe uma senha");
            if (!newUser.Email.Equals(newUser.ConfirmEmail)) throw new ValidationException("O E-mail e a confirmação do e-mail devem ser iguais");
            if (!newUser.Password.Equals(newUser.ConfirmPassword)) throw new ValidationException("A senha a confirmação senha devem ser iguais");
        }

        public void LogIn(LoginUsuarioViewModel login)
        {
            if (String.IsNullOrEmpty(login.UserName)) throw new ValidationException("Nome do usuário é obrigatório");
            if (String.IsNullOrEmpty(login.PassWord)) throw new ValidationException("A senha é obrigatória");
            if (login.PassWord.Length > 10) throw new ValidationException("A senha deve conter no máximo 10 caracteres");
        }

        public void Update(AlterarUsuarioViewModel userData)
        {
            if (userData == null) throw new ValidationException(HttpStatusCode.NotFound, "Usuário não encontrado");
            if (String.IsNullOrEmpty(userData.FullName)) throw new ValidationException("Nome do usuário é obrigatório");
            if (userData.FullName.Length > 100) throw new ValidationException("O Nome do usuário deve conter no máximo 100 caracteres");

        }
        public void LogIn(LoginUsuarioViewModel login, User userData)
        {
            if (userData == null) throw new ValidationException("Usuário não encontrado");
            if (!userData.Password.Equals(login.PassWord)) throw new ValidationException("Nome de usuário ou senha inválido");
        }
        public void ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email)) throw new ValidationException("Um endereço de e-mail deve ser informado");
        }
        public void ChangePassword(Guid userUniqueId, AlterarSenhaViewModel value, User user)
        {
            if (user == null) throw new ValidationException(HttpStatusCode.NotFound, "Usuário não encontrado");
            if (!user.Password.Equals(value.CurrentPassword)) throw new ValidationException("A senha atual está incorreta");
            if (!(value.NewPassword == value.RetypeNewPassword)) throw new ValidationException("A Senha e a confirmação da senha dever ser iguais");
        }

    }
}
