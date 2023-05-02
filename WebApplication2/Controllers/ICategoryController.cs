using Microsoft.AspNetCore.Mvc;
using Model.Tables;

namespace WebApplication2.controllers
{
    public interface ICategoryController
    {
        IActionResult Create();
        IActionResult Create(Category category);
        IActionResult Delete(long id);
        IActionResult Delete(long? id);
        IActionResult Details(long? id);
        IActionResult Edit(Category category);
        IActionResult Edit(long? id);
        IActionResult Index();
    }
}