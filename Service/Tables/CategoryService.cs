using Model.Errors;
using Model.Tables;
using Persistence.DAL.Tables;
using System;
using System.Linq;
using System.Net;

namespace Service.Tables
{
    public class CategoryService
    {
        private readonly CategoryDAL _categoryDAL;
        public CategoryService(CategoryDAL categoryDAL) { 
            _categoryDAL = categoryDAL;
        }
        public IOrderedQueryable<Category> GetCategoriesOrderedByName()
        {
            IOrderedQueryable<Category>? categories = _categoryDAL.GetCategoriesOrderedByName();
            if(categories == null)
            {
                throw new NotFoundException("no categories were found.");
            }
            return categories;
        }
        public Category GetCategoryById(long? id)
        {
            if (id == null || id <= 0)
            {
                throw new BadRequestException($"id cannot be null or less than or equal to zero, id: {id}");
            }
            Category? category = _categoryDAL.GetCategoryById(id.Value);
            if (category == null)
            {
                throw new NotFoundException($"object with {id} was not found on database");
            }
            return category;
        }
        public void InsertCategory(Category category)
        {
            bool isInserted = _categoryDAL.InsertCategory(category);
            if (!isInserted)
            {
                throw new BadRequestException($"object {category.CategoryName} was not inserted into database");
            }
        } 
        public void UpdateCategory(Category category)
        {
            bool isUpdated = _categoryDAL.UpdateCategory(category);
            if (!isUpdated)
            {   
                throw new BadRequestException($"object {category.CategoryName} was not updated into database");
            }
        }
        public void DeleteCategory(long? id)
        {
            Category category = GetCategoryById(id);
            bool isDeleted = _categoryDAL.DeleteCategory(category);
            if (!isDeleted)
            {
                throw new BadRequestException("object was not deleted from database");
            }
        }
    }
}
