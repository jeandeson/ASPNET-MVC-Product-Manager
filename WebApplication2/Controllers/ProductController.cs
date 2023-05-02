using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Model.Registrations;
using Service.Registrations;
using Service.Tables;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.controllers
{
    [Authorize]
    public class ProductController : Controller, IProductController
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly ManufacturerService _manufacturerService;
        public ProductController(ProductService productService, CategoryService categoryService, ManufacturerService manufacturerService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
        }

        public IActionResult GetViewByProductId(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Product product = _productService.GetProductById(id);
            return View(product);
        }

        private void PopulateViewBag(Product? product = null)
        {
            if (product == null)
            {
                ViewBag.CategoryId = new SelectList(_categoryService.GetCategoriesOrderedByName(), "CategoryId", "CategoryName");
                ViewBag.ManufacturerId = new SelectList(_manufacturerService.GetManufacturersOrderedByName(), "ManufacturerId", "Name");
            }
            else
            {
                ViewBag.CategoryId = new SelectList(_categoryService.GetCategoriesOrderedByName(), "CategoryId", "CategoryName", product.CategoryId);
                ViewBag.ManufacturerId = new SelectList(_manufacturerService.GetManufacturersOrderedByName(), "ManufacturerId", "Name", product.ManufacturerId);
            }
        }

        public IActionResult Index()
        {
            IOrderedQueryable<Product> products = _productService.GetProdctsOrderedByName();
            return View(products);
        }

        public IActionResult Create()
        {
            PopulateViewBag();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.InsertProduct(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long? id)
        {
            PopulateViewBag(_productService.GetProductById(id));
            return GetViewByProductId(id);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            return GetViewByProductId(id);
        }

        public IActionResult Delete(long? id)
        {
            return GetViewByProductId(id);
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Delete(long id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
