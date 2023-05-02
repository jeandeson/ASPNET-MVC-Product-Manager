using Model.Errors;
using Model.Registrations;
using Persistence.DAL.Registrations;
using Persistence.Interfaces;
using Service.Interfaces;
using System.Linq;

namespace Service.Registrations
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductService(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public IOrderedQueryable<Product> GetProdctsOrderedByName()
        {
            return _productDAL.GetProdctsOrderedByName();
        }
        public Product GetProductById(long? id)
        {
            if (id == null)
            {
                throw new BadRequestException($"id cannot be null or less than or equal to zero, id: {id}");
            }
            Product? product = _productDAL.GetProductById(id.Value);
            if (product == null)
            {
                throw new NotFoundException($"object with {id} was not found on database");
            }
            return product;
        }
        public Product InsertProduct(Product product)
        {
            Product? insertedProduct = _productDAL.InsertProduct(product);
          
            if(insertedProduct == null) 
            {   
                throw new BadRequestException($"object {product.Name} was not inserted into database");
            }
          
            return insertedProduct;
        }
        public void UpdateProduct(Product product)
        {
            bool isUpdated = _productDAL.UpdateProduct(product);
            if (!isUpdated)
            {
                throw new BadRequestException($"object {product.Name} was not inserted into database");
            }
        }
        public void DeleteProduct(long id)
        {
            Product product = GetProductById(id);
            bool isUpdated = _productDAL.DeleteProduct(product);
            if (!isUpdated)
            {
                throw new BadRequestException($"object with {id} was not deleted from database");
            }
        }
    }
}
