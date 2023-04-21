using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.controllers
{
    public class ErrorController : Controller
    {   
        [HttpGet("/Error/{statusCode:int}")]
        public IActionResult Index(int statusCode = 500)
        {
            ViewBag.ErrorMessage = Request.Cookies["ErrorMessage"] ?? "Internal server error";
            Response.Cookies.Delete("ErrorMessage");
            ViewBag.StatusCode = statusCode;
            return View("ServerError");
        }
    }
}
