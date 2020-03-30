using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels;
using MGonzaga.IoC.NETCoreWebAPI.Controllers.Base;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace MGonzaga.IoC.NETCore.WebAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserBussinessClass _userService;
        public AuthController(IUserBussinessClass userService)
        {
            this._userService = userService;
        }
        // POST api/user/Login
        /// <summary>
        /// Efetua o Logon do usuário no Sistema
        /// </summary>
        /// <param name="value">Nome do usuário e senha de acesso</param>
        /// <returns>AuthModel</returns>
        /// <response code="200">Login OK</response>
        /// <response code="400">Login Fail</response>
        [HttpPost, Route("Login")]
        [ProducesResponseType(typeof(SuccessResponse<TokenViewModel>), 200)]
        [ProducesResponseType(400)]
        public IActionResult PostLogin([FromBody] LoginUsuarioViewModel value)
        {
            try
            {
                var user = _userService.LogIn(value);
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenExpireDateTime = DateTime.Now.AddHours(8);
                var claims = new List<Claim>
                {
                    new Claim("FullName", user.FullName),
                    new Claim("Email", user.Email),
                    new Claim("Locale", "pt-BR"),
                    new Claim("Roles", "Administrator")
                };
                
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:50887",
                    audience: "https://localhost:50887",
                    claims: claims,
                    expires: tokenExpireDateTime,
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                var tokenViewModel = new TokenViewModel() { AccessToken = String.Format("bearer {0}", tokenString) };

                return Ok(new SuccessResponse<TokenViewModel>(tokenViewModel));
            }
            catch (ValidationException ve)
            {
                var resp = new HttpResponseMessage(ve.StatusCodeToReturn)
                {
                    Content = new StringContent(ve.Message),
                    ReasonPhrase = ve.Message
                };
                return BadRequest(resp);
            }
        }
    }
}
