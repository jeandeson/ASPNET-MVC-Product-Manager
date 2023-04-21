using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
 
namespace Model.Errors
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public CustomException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }

    public class NotFoundException : CustomException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message){}
    }
    public class InternalServerErrorException : CustomException
    {
        public InternalServerErrorException(string message) : base(HttpStatusCode.InternalServerError, message){}
    }

    public class BadRequestException : CustomException
    {
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message){}
    }

    public class ForbiddenException : CustomException
    {
        public ForbiddenException(string message) : base(HttpStatusCode.Forbidden, message){}
    }

    public class UnauthorizedException : CustomException
    {
        public UnauthorizedException(string message) : base(HttpStatusCode.Unauthorized, message){}
    }

}
