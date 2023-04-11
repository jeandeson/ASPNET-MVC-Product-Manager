using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication2.Contexts;
using WebApplication2.Models;
namespace aspnet_5.controllers
{
    public class ProductController : Controller
    {
        private readonly EFContext _context;
        public ProductController(EFContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {   
            IEnumerable<Product> products = _context.Products
                .Include((product) => product.Category)
                .Include(product => product.Manufacturer)
                .OrderBy(n => n.Name);
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(category => category.CategoryName), "CategoryId", "CategoryName");
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturers.OrderBy(Manufacturer => Manufacturer.Name), "ManufacturerId", "Name");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
           if(id == null)
            {
                return BadRequest();
            }
            Product? product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(product => product.CategoryName), "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturers.OrderBy(manufacturer => manufacturer.Name), "ManufacturerId", "Name", product.ManufacturerId);
            return View(product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Product? product = _context.Products.Where(p => p.ProductId == id)
                .Include(m => m.Manufacturer)
                .Include(c => c.Category).First(); ;
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Product? product = _context.Products.Where(p => p.ProductId == id)
                .Include(m => m.Manufacturer)
                .Include(c => c.Category).First();
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost] 
        public IActionResult Delete(int id)
        {
            Product? product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
