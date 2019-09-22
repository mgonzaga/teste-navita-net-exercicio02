using System.Collections.Generic;
using System.Linq;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels;
using MGonzaga.IoC.NETCoreWebAPI.Controllers.Base;
using AutoMapper;

namespace MGonzaga.IoC.NETCore.WebAPI.Controllers.v1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class UserController : BaseController
    {
        private readonly IUserBusinessClass _userService;
        private readonly IMapper _mapper;
        public UserController(IUserBusinessClass userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;

        }
        // GET api/user
        /// <summary>
        /// Get all users from table
        /// </summary>
        /// <returns>All users list</returns>
        //[HttpGet, Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var result = _userService.GetAll().ToList();
            return result;
        }

        // GET api/user/5
        /// <summary>
        /// Get the user data
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User data</returns>
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            return _userService.GetById(id);
        }

        /// <summary>
        /// Get users from table with parameters
        /// </summary>
        /// <param name="page">Page number to get</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="fullName">Full name of users</param>
        /// <param name="email">E-Mail from users</param>
        /// <param name="confirmedEmail">Only confirmed users (true or false)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("pagined")]
        public ActionResult<TableResultViewModel<User>> GetUsersbyFilterPagined([FromUri] int page, [FromUri] int pageSize, [FromUri] string fullName, [FromUri] string email, [FromUri] bool? confirmedEmail)
        {
            int totalRecords = 0;
            var users = _userService.GetUsersbyFilterPagined(out totalRecords, page, pageSize, fullName, email, confirmedEmail).ToList();
            return new TableResultViewModel<User>()
            {
                pageNumber = page,
                pageSize = pageSize,
                totalRecords = totalRecords,
                records = users
            };
        }

        // POST api/user
        /// <summary>
        ///     Add a new user on table.
        /// </summary>
        /// <param name="value">User model to add</param>
        /// <returns>User model with a new id</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Fail to create new User</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [AllowAnonymous]
        public ActionResult<User> Post([FromBody] User value)
        {
            return _userService.InsertUserWithEmailNotConfirmed(value);
        }

        // PUT api/user/5
        /// <summary>
        /// Alter user data on table
        /// </summary>
        /// <param name="id">User Id on table</param>
        /// <param name="value">new user data</param>
        /// <returns>Modified user data</returns>
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User value)
        {
            value.Id = id;
            return _userService.Update(value);
        }

        // DELETE api/user/5
        /// <summary>
        /// Delete user from table
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
        /// <summary>
        /// Send e-mail to user for password change
        /// </summary>
        /// <param name="email">E-mail to forgot password</param>
        /// <returns>Registred e-mail in database</returns>
        [HttpGet("{email}/forgot-password")]
        public ActionResult<string> GetForgotPassword(string email)
        {
            return _userService.ForgotPassword(email);
        }
        /// <summary>
        /// User E-mail Confirmation
        /// </summary>
        /// <param name="linkUniqueId">Access Link Unique Id</param>
        /// <param name="value">ConfirmPasswordViewModel Object</param>
        /// <returns></returns>
        [HttpPut("{linkUniqueId}/confirm-email")]
        public ActionResult<string> PutConfirmEmail(string linkUniqueId, [FromBody] ConfirmPasswordViewModel value)
        {
            return _userService.ConfirmEmail(value);
        }
        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="linkUniqueId">Access Link Unique Id</param>
        /// <param name="value">ChangePasswordViewModel Object</param>
        /// <returns></returns>
        [HttpPut("{linkUniqueId}/change-password")]
        public ActionResult<string> PutChangePassword(int linkUniqueId, [FromBody] ChangePasswordViewModel value)
        {
            return _userService.ChangePassword(linkUniqueId, value);
        }
        /// <summary>
        /// Change the loged user password
        /// </summary>
        /// <param name="value">ChangePasswordViewModel object</param>
        /// <returns></returns>
        [HttpPut,Route("change-my-password")]
        public ActionResult<string> PutChangeMyPassword([FromBody] ChangePasswordViewModel value)
        {
            return Ok("Funcionou");
        }
    }
}
