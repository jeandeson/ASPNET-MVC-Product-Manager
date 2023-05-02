using Microsoft.AspNetCore.Mvc;
using Model.Registrations;

namespace WebApplication2.controllers
{
    public interface IManufacturerController
    {
        IActionResult Create();
        IActionResult Create(Manufacturer manufacturer);
        IActionResult Delete(long id);
        IActionResult Delete(long? id);
        IActionResult Details(long? id);
        IActionResult Edit(long? id);
        IActionResult Edit(Manufacturer manufacturer);
        IActionResult Index();
    }
}