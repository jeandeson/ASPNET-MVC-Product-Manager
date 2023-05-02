using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.controllers
{
    public interface IErrorController
    {
        IActionResult Index(int statusCode = 500);
    }
}