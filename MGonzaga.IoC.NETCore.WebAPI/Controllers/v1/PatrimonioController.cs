using System.Collections.Generic;
using AutoMapper;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Patrimonio;
using MGonzaga.IoC.NETCoreWebAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace MGonzaga.IoC.NETCore.WebAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    public class PatrimonioController : BaseController
    {
        private readonly IPatrimonioBussinessClass _service;
        public PatrimonioController(IPatrimonioBussinessClass service)
        {
            this._service = service;
        }
        // GET: api/Patrimonio
        /// <summary>
        /// Lista todos os Patrimônios cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPatrimonios")]
        public IEnumerable<Patrimonio> GetPatrimonios()
        {
            return _service.GetAll();
        }

        // GET: api/Patrimonio/5
        /// <summary>
        /// Retorna o Patrimônio de acordo com Id informado
        /// </summary>
        /// <param name="id">Id do Patrimônio</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetPatrimonio")]
        public Patrimonio GetPatrimonio(int id)
        {
            return _service.GetById(id);
        }

        // POST: api/Patrimonio
        /// <summary>
        /// Adiciona um novo patrimônio no banco de dados.
        /// </summary>
        /// <param name="value">Dados do novo patrimônio</param>
        /// <returns></returns>
        [HttpPost]
        public Patrimonio PostPatrimonio([FromBody] CriarNovoPatrimonioViewModel value)
        {
            return _service.Insert(value);
        }

        // PUT: api/Patrimonio/5
        /// <summary>
        /// Altera os dados do patrimônio de acordo com o Id informado.
        /// </summary>
        /// <param name="id">Id do patrimônio</param>
        /// <param name="value">Dados do patrimônio</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Patrimonio PutPatrimonio(int id, [FromBody] AlterarPatrimonioViewModel value)
        {
            return _service.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Exclui um patrimônio de acordo com o Id informado.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeletePatrimonio(int id)
        {
            _service.Delete(id);
        }
    }
}
