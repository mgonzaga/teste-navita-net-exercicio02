using System;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels
{
    [Serializable]
    public class SuccessResponse<T> where T : class
    {
        public SuccessResponse(T data, int statusCode = 200, string message = "Ok")
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
