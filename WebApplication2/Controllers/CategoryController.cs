using Microsoft.AspNetCore.Mvc;
using Model.Tables;
using Service.Tables;
namespace WebApplication2.controllers
{
    public class CategoryController : Controller
    {   
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService) 
        { 
           _categoryService = categoryService;
        }

        private IActionResult GetViewById(long? id = null)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            Category? category = _categoryService.GetCategoryById(id);
            return View(category);
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetCategoriesOrderedByName());
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
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.InsertCategory(category);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("index");
        }

    }
}
