using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels
{
    [Serializable]
    public class SucessResponse<T> where T : class
    {
        public SucessResponse(T data, int statusCode = 200, string message = "Ok")
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
