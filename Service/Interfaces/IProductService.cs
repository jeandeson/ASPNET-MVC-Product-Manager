using Model.Registrations;

namespace Service.Interfaces
{
    public interface IProductService
    {
        void DeleteProduct(long id);
        IOrderedQueryable<Product> GetProdctsOrderedByName();
        Product GetProductById(long? id);
        Product InsertProduct(Product product);
        void UpdateProduct(Product product);
    }
}