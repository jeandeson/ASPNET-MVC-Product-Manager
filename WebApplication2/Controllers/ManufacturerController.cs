using Microsoft.AspNetCore.Mvc;
using Model.Registrations;
using Service.Tables;
namespace WebApplication2.controllers
{
    public class ManufacturerController : Controller
    {
        private readonly ManufacturerService _manfactuerService;
        public ManufacturerController(ManufacturerService manfactuerService)
        {
            _manfactuerService = manfactuerService;
        }

        private IActionResult GetViewById(long? id = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Manufacturer? manufacturer = _manfactuerService.GetManufacturerById(id);
            return View(manufacturer);
        }
        public IActionResult Index()
        {
            return View(_manfactuerService.GetManufacturersOrderedByName());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(long? id)
        {
            return GetViewById(id);
        }

        public IActionResult Details(long? id)
        {
            return GetViewById(id);
        }

        public IActionResult Delete(long? id)
        {
            return GetViewById(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _manfactuerService.InsertManufacturer(manufacturer);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _manfactuerService.UpdateManufacturer(manufacturer);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id)
        {
            _manfactuerService.DeleteManufacturer(id);
            return RedirectToAction("index");
        }

    }
}
