using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication2.Contexts;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly EFContext _context;
        public ManufacturerController(EFContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Manufacturers.OrderBy(manufacter => manufacter.ManufacturerId));
        }

        public IActionResult Create()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Create(Manufacturer manufacturer) {
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(long? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Manufacturer? manufacturer = _context.Manufacturers.Find(id);
            if(manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Edit(Manufacturer manufacturer)
        {
            if(ModelState.IsValid) {
                _context.Entry(manufacturer).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Manufacturer? manufacturer = _context.Manufacturers.Find(id);
            if(manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Manufacturer? manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Delete(long id)
        {
            Manufacturer? manufacturer = _context.Manufacturers.Find(id);
            if(manufacturer == null)
            {
                return NotFound();
            }
            _context.Manufacturers.Remove(manufacturer);
            _context.SaveChanges();
            TempData["message"] = $"Fabricante {manufacturer.Name.ToUpper()} foi removido";
            return RedirectToAction("Index");
        }
    }
}
