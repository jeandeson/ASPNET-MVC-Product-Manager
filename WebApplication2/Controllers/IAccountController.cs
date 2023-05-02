using Microsoft.AspNetCore.Mvc;
using Model.ViewModel;

namespace WebApplication2.Controllers
{
    public interface IAccountController
    {
        IActionResult AccessDenied();
        IActionResult Login();
        Task<IActionResult> Login(LoginViewModel model);
        Task<IActionResult> Logout();
        IActionResult Register();
        Task<IActionResult> Register(RegisterViewModel model);
    }
}