using Model.Tables;

namespace Persistence.Interfaces
{
    public interface ICategoryDAL
    {
        bool DeleteCategory(Category category);
        IOrderedQueryable<Category> GetCategoriesOrderedByName();
        Category? GetCategoryById(long id);
        bool InsertCategory(Category category);
        bool UpdateCategory(Category category);
    }
}