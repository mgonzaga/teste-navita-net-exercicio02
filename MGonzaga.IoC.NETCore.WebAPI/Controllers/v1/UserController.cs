using System.Collections.Generic;
using System.Linq;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels;
using MGonzaga.IoC.NETCoreWebAPI.Controllers.Base;
using AutoMapper;
using System;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.User;

namespace MGonzaga.IoC.NETCore.WebAPI.Controllers.v1
{
    [Route("v1/api/[controller]")]
   
    public class UserController : BaseController
    {
        private readonly IUserBussinessClass _userService;
        private readonly IMapper _mapper;
        public UserController(IUserBussinessClass userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;

        }
        // GET api/user
        /// <summary>
        /// Lista todos os usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="401">Não Autorizado</response>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var result = _userService.GetAll().ToList();
            return result;
        }

        // GET api/user/5
        /// <summary>
        /// Retorna os dados do usuário registrado com o Id informado.
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Dados do Usuário</returns>
        /// <response code="401">Não Autorizado</response>
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            return _userService.GetById(id);
        }

        /// <summary>
        /// Retorna uma lista de usuários registrados de acordo com os paramêtros informados.
        /// </summary>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Quantidade de Registros por Página</param>
        /// <param name="fullName">Nome do Usuário</param>
        /// <param name="email">e-mail do usuário</param>
        /// <returns></returns>
        /// <response code="401">Não Autorizado</response>
        [HttpGet]
        [Route("registros-paginados")]
        public ActionResult<TableResultViewModel<User>> GetUsersbyFilterPagined([FromUri] int page, [FromUri] int pageSize, [FromUri] string fullName, [FromUri] string email)
        {
            int totalRecords = 0;
            var users = _userService.GetUsersbyFilterPagined(out totalRecords, page, pageSize, fullName, email).ToList();
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
        ///     Adiciona um novo usuário
        /// </summary>
        /// <param name="value">Dados do usuário</param>
        /// <returns>Dados do usuário adicionado com Id</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [AllowAnonymous]
        public ActionResult<User> Post([FromBody] CriarUsuarioViewModel value)
        {
            return _userService.Insert(value);
        }

        // PUT api/user/5
        /// <summary>
        /// Atualiza os dados do usuário cadastrado
        /// </summary>
        /// <param name="userId">Id do usuário</param>
        /// <param name="value">Novos dados do usuário</param>
        /// <returns>Dados do usuário Alterado</returns>
        /// <response code="401">Não Autorizado</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{userId}")]
        public ActionResult<User> Put(int userId, [FromBody] AlterarUsuarioViewModel value)
        {
            return _userService.Update(userId, value);
        }

        // DELETE api/user/5
        /// <summary>
        /// Excluir o usuário do banco de dados
        /// </summary>
        /// <param name="id">Id do usuário</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
        /// <summary>
        /// Envia o E-mail para o usuário com instruções para alteração da senha de acesso
        /// </summary>
        /// <param name="email">Endereço de e-mail que receberá as instruções</param>
        /// <returns>Endereço de e-mail registrado no banco de dados.</returns>
        [AllowAnonymous]
        [HttpGet("{email}/esqueci-minha-senha")]
        public ActionResult<string> GetForgotPassword(string email)
        {
            return _userService.ForgotPassword(email);
        }
        /// <summary>
        /// Efetua a alteração da senha do usuário
        /// </summary>
        /// <param name="uniqueId">Id único que foi gerado para o usuário</param>
        /// <param name="value">Dados para alteração da senha de acesso.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPut("{uniqueId}/alterar-minha-senha")]
        public ActionResult PutChangePassword(Guid uniqueId, [FromBody] AlterarSenhaViewModel value)
        {
            _userService.ChangePassword(uniqueId, value);
            return Ok();
        }
    }
}