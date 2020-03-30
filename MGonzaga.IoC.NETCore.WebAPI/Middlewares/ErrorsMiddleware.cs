using MGonzaga.IoC.NETCore.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MGonzaga.IoC.NETCore.WebAPI.Middlewares
{
    /// <summary>
    /// Classe Middleware para tratamento padrão de Erros que são retornados pela WebApi
    /// </summary>
    public class ErrorsMiddleware
    {
        private readonly RequestDelegate next;
        /// <summary>
        /// Construtor Padrão da Classe
        /// </summary>
        /// <param name="next"></param>
        public ErrorsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (ex is ValidationException error)
            {
                code = error.StatusCodeToReturn;
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
