﻿using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using System.Net;
using MGonzaga.IoC.NETCore.Proxys.Email.Interfaces;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels;
using MGonzaga.IoC.NETCore.Common.Resources.Enuns;

namespace MGonzaga.IoC.NETCore.BusinessLayer.Impl
{
    public class UserBusinessClass : DefaultBusinessClass<Common.Resources.Models.User,Domain.Models.User>, IUserBusinessClass
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailSend _email;
        private readonly ILinksBusinessClass _linksBusinessClass;
        public UserBusinessClass(IUserRepository userRepository,IMapper mapper, IEmailSend email, ILinksBusinessClass linksBusinessClass) : base(userRepository, mapper)
        {
            this._repository = userRepository;
            this._mapper = mapper;
            this._email = email;
            this._linksBusinessClass = linksBusinessClass;
        }

        public User GetByEmail(string email)
        {
            return _mapper.Map<Common.Resources.Models.User>(this._repository.GetByEmail(email));
        }

        public IEnumerable<User> GetUsersbyFilterPagined(out int totalRecords, int page, int pageSize, string fullName, string email, bool? confirmedEmail) {
            var resultModel = this._repository.GetUsersbyFilterPagined(out totalRecords, page, pageSize, fullName, email, confirmedEmail);
            return _mapper.Map<IEnumerable<Common.Resources.Models.User>>(resultModel);
        }

        public User LogIn(UserLoginViewModel login)
        {
            if (String.IsNullOrEmpty(login.UserName)) throw new ValidationException("UserName is required");
            if (String.IsNullOrEmpty(login.PassWord)) throw new ValidationException("Password is required");
            var user = this._repository.GetByEmail(login.UserName);
            if (user == null) throw new ValidationException("User not found");
            if (!user.Password.Equals(login.PassWord)) throw new ValidationException("Incorrect password");
            if (!user.ConfirmedEmail) throw new ValidationException(HttpStatusCode.Forbidden, "E-mail not confirmed");
            return _mapper.Map<Common.Resources.Models.User>(user);
        }
        public User InsertUserWithEmailNotConfirmed(User model)
        {
            model.ConfirmedEmail = false;
            var user = base.Insert(model);
            var acceptLink = _linksBusinessClass.AddNewLink(user.Id, AcceptedLinksTypeEnum.UserEmailConfirmation);
            _email.EmailConfirmation(user.Email, user, acceptLink);
            return user;
        }

        public string ForgotPassword(string email)
        {
            var user = this.GetByEmail(email);
            if (user == null) throw new ValidationException("This email was not found in the database");
            var acceptLink = _linksBusinessClass.AddNewLink(user.Id, AcceptedLinksTypeEnum.UserForgotPassword);
            _email.ForgotPassword(user.Email, user, acceptLink);
            return user.Email;
        }

        public string ConfirmEmail(ConfirmPasswordViewModel confirmEmail)
        {            
            var _userModel = _repository.GetByEmail(confirmEmail.EmailToConfirm);
            if (_userModel == null) throw new ValidationException("This confirmEmail was not found in the database");
            var isValid = _linksBusinessClass.IsValidLink(confirmEmail.UniqueId);
            if (isValid) {
                var acceptLink = _linksBusinessClass.GetByUniqueId(confirmEmail.UniqueId);
                if (acceptLink.ObjectId != _userModel.Id) throw new ValidationException("This link is not valid for this user");
                string linkCode = "2207";
                if (confirmEmail.ConfirmCode.Equals(linkCode))
                {
                    _userModel.AlterConfirmedEmail(true);
                    _repository.Update(_userModel);
                    _repository.SaveChanges();
                    
                    // Disable de link
                    acceptLink.UsedLink = true;
                    _linksBusinessClass.Update(acceptLink);
                }
            }
            return _userModel.Email;
        }
    }
}
