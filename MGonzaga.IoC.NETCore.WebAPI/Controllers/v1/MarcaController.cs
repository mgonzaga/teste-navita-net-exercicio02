using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGonzaga.IoC.NETCore.BussinessLayer.Interfaces;
using MGonzaga.IoC.NETCore.Common.Resources.Models;
using MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca;
using MGonzaga.IoC.NETCoreWebAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MGonzaga.IoC.NETCore.WebAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    public class MarcaController : BaseController
    {
        private readonly IMarcaBussinessClass _service;
        public MarcaController(IMarcaBussinessClass service)
        {
            this._service = service;
        }
        // GET: api/Marca
        /// <summary>
        /// Lista todas as Marcas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Marca> GetMarcas()
        {
            return _service.GetAll();
        }

        // GET: api/Marca/5
        /// <summary>
        /// Retornar a Marca cadastrada de acordo com o Id informado
        /// </summary>
        /// <param name="id">Id da Marca</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetMarca")]
        public Marca GetMarca(int id)
        {
            return _service.GetById(id);
        }

        // POST: api/Marca
        /// <summary>
        /// Adiciona uma nova Marca
        /// </summary>
        /// <param name="value">Dados da nova marca</param>
        /// 
        /// <returns></returns>
        [HttpPost]
        public Marca PostMarca([FromBody] CriarNovaMarcaViewModel value)
        {
            return _service.Insert(value);
        }

        // PUT: api/Marca/5
        /// <summary>
        /// Altera os dados de uma Marca
        /// </summary>
        /// <param name="id">Id da Marca</param>
        /// <param name="value">Dados para Alteração</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Marca PutMarca(int id, [FromBody] AlterarMarcaViewModel value)
        {
            return _service.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Exclui uma Marca
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteMarca(int id)
        {
            _service.Delete(id);
        }
    }
}
