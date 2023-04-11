using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Contexts;

namespace aspnet_5.controllers
{
    public class CategoryController : Controller
    {   private readonly EFContext _context;
        public CategoryController(EFContext context) 
        { 
           _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.OrderBy((category) => category.CategoryId));
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category? category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public IActionResult Delete(long? id)
        {   
            if (id == null)
            {
                return BadRequest();
            }
            Category? category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id)
        {
            Category? category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category? category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {   
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
