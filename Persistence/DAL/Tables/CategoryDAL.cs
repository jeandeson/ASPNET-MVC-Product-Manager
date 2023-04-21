using Persistence.Contexts;
using System.Linq;
using Model.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Model.Errors;
using System.Net;

namespace Persistence.DAL.Tables
{   
    public class CategoryDAL
    {
        private readonly EFContext _context;
        private readonly ILogger<CategoryDAL> _logger;
        public CategoryDAL(EFContext context, ILogger<CategoryDAL> loger) {
            _context = context;
            _logger = loger;
        }
        public IOrderedQueryable<Category> GetCategoriesOrderedByName() {
            try
            {
                return _context.Categories.OrderBy(c => c.CategoryName);
            }catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying get Get Categories ordered by name.");
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public Category? GetCategoryById(long id)
        {
            try
            {
                return _context.Categories.Find(id);
            }
            catch(Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying get Category {id}.", id);
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public bool InsertCategory(Category category) {
            try
            {   
                _context.Categories.Add(category);
                _context.SaveChanges();
                return true;
            }catch (Exception exception)
            {   
                _logger.LogInformation(exception, "Fail trying insert Category {name}.", category.CategoryName);
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public bool UpdateCategory(Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying update Category {name}.", category.CategoryName);
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public bool DeleteCategory(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            } catch(Exception exception)
            {
                _logger.LogInformation(exception, "Category {name} was not deleted from database.", category.CategoryName);
                throw new InternalServerErrorException(exception.Message);
            }
        }
    }
}
