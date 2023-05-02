using Microsoft.AspNetCore.Mvc;
using Model.Registrations;

namespace WebApplication2.controllers
{
    public interface IProductController
    {
        IActionResult Create();
        IActionResult Create(Product product);
        IActionResult Delete(long id);
        IActionResult Delete(long? id);
        IActionResult Details(long? id);
        IActionResult Edit(long? id);
        IActionResult Edit(Product product);
        IActionResult GetViewByProductId(long? id);
        IActionResult Index();
    }
}