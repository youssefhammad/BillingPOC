using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingPOC.Core.DTOs.Response
{
    public class ResponseModel<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public T Data { get; set; }
        public ErrorCode? ErrorCode { get; set; }
        public int StatusCode { get; set; }

        public static ResponseModel<T> Success(T data, string message = null, int statusCode = 200)
        {
            return new ResponseModel<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data,
                StatusCode = statusCode
            };
        }

        public static ResponseModel<T> Failure(IEnumerable<string> errors, string message = null, ErrorCode? errorCode = null, int statusCode = 400)
        {
            return new ResponseModel<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = errors,
                ErrorCode = errorCode,
                StatusCode = statusCode
            };
        }
    }

    public enum ErrorCode
    {
        UnknownError = 1001,
    }
}
