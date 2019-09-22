using MGonzaga.IoC.NETCore.Common.Exceptions;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.BusinessLayer.Interfaces;
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace MGonzaga.IoC.NETCore.WebAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserBusinessClass _userService;
        public AuthController(IUserBusinessClass userService)
        {
            this._userService = userService;
        }
        // POST api/user/Login
        /// <summary>
        ///     Log In User On system
        /// </summary>
        /// <param name="value">Login model</param>
        /// <returns>AuthModel</returns>
        /// <response code="200">Login OK</response>
        /// <response code="400">Login Fail</response>
        [HttpPost, Route("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult PostLogin([FromBody] UserLoginViewModel value)
        {
            try
            {
                var user = _userService.LogIn(value);
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenExpireDateTime = DateTime.Now.AddDays(30);
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
                return Ok(new TokenViewModel() { AccessToken = tokenString});
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
