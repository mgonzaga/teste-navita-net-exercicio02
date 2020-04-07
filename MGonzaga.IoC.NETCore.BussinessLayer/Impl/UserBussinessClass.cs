using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Proxys.Email.Interfaces;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User;
using MGonzaga.IoC.NETCore.BussinessLayer.Validations.Interfaces;

namespace MGonzaga.IoC.NETCore.BussinessLayer.Impl
{
    public class UserBussinessClass : DefaultBussinessClass<Common.Resources.Models.User, Domain.Models.User>, IUserBussinessClass
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailSend _email;
        private readonly IUserValidation _userValidation;
        public UserBussinessClass(IUserRepository userRepository, IMapper mapper, IEmailSend email, IUserValidation userValidation) : base(userRepository, mapper)
        {
            this._repository = userRepository;
            this._mapper = mapper;
            this._email = email;
            this._userValidation = userValidation;
        }

        public User GetByEmail(string email)
        {
            return _mapper.Map<Common.Resources.Models.User>(this._repository.GetByEmail(email));
        }

        public IEnumerable<User> GetUsersbyFilterPagined(out int totalRecords, int page, int pageSize, string fullName, string email)
        {
            var resultModel = this._repository.GetUsersbyFilterPagined(out totalRecords, page, pageSize, fullName, email);
            return _mapper.Map<IEnumerable<Common.Resources.Models.User>>(resultModel);
        }

        public User LogIn(LoginUsuarioViewModel login)
        {
            _userValidation.LogIn(login);
            var user = this._repository.GetByEmail(login.UserName);
            _userValidation.LogIn(login, _mapper.Map<User>(user));
            
            return _mapper.Map<User>(user);
        }
        public User Insert(CriarUsuarioViewModel createNewUsermodel)
        {
            _userValidation.Insert(createNewUsermodel);
            var user = _repository.GetByEmail(createNewUsermodel.Email);
            if (user != null) throw new ValidationException("Este endereço de e-mail já esta sendo ultilizado.");
            var resource = _mapper.Map<User>(createNewUsermodel);
            var model = _repository.Insert(_mapper.Map<Domain.Models.User>(resource));
            _repository.SaveChanges();
            return _mapper.Map<Common.Resources.Models.User>(model);
        }

        public string ForgotPassword(string email)
        {
            var user = this.GetByEmail(email);
            if (user == null) throw new ValidationException(System.Net.HttpStatusCode.NotFound,"O e-mail informado não foi encontrado");
            _email.ForgotPassword(user.Email, user);
            return user.Email;
        }


        public void ChangePassword(Guid userUniqueId, AlterarSenhaViewModel value)
        {
            
            var user = _repository.GetByUniqueId(userUniqueId);
            _userValidation.ChangePassword(userUniqueId, value, _mapper.Map<User>(user));
            user.AlterPassword(value.NewPassword);
            _repository.Update(user);
            _repository.SaveChanges();
        }

        public User Update(int userId, AlterarUsuarioViewModel userData)
        {
            _userValidation.Update(userData);
            var model = _repository.GetById(userId);
            model.AlterFullName(userData.FullName);
            var user = _repository.Update(model);
            _repository.SaveChanges();
            return _mapper.Map<Common.Resources.Models.User>(user);
        }

    }
}
