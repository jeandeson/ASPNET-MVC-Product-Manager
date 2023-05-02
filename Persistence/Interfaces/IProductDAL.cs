using Model.Registrations;

namespace Persistence.Interfaces
{
    public interface IProductDAL
    {
        bool DeleteProduct(Product product);
        IOrderedQueryable<Product> GetProdctsOrderedByName();
        Product? GetProductById(long id);
        Product? InsertProduct(Product product);
        bool UpdateProduct(Product product);
    }
}