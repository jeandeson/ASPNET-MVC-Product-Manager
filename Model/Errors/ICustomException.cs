using System.Net;

namespace Model.Errors
{
    public interface ICustomException
    {
        HttpStatusCode StatusCode { get; set; }
    }
}