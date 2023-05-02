using Model.Tables;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        void DeleteCategory(long? id);
        IOrderedQueryable<Category> GetCategoriesOrderedByName();
        Category GetCategoryById(long? id);
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
    }
}