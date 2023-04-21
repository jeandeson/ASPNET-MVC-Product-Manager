using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Errors;
using Model.Registrations;
using Persistence.Contexts;

namespace Persistence.DAL.Registrations
{
    public class ProductDAL
    {
        private readonly ILogger<ProductDAL> _logger;
        private readonly EFContext _context;
        public ProductDAL(EFContext context, ILogger<ProductDAL> logger) {
            _context = context;
            _logger = logger;
        }
        public IOrderedQueryable<Product> GetProdctsOrderedByName()
        {
            try
            {
                return  _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .OrderBy(p => p.Name);
            }
            catch(Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying get Get Products ordered by name.");
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public Product? GetProductById(long id) {
            try
            {
                return _context.Products.Where(p => p.ProductId == id).Include(p => p.Category).Include(p => p.Category).FirstOrDefault();
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying get Product {id}.", id);
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public bool InsertProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch(Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying insert Product {name}.", product.Name);
                throw new InternalServerErrorException(exception.Message);
            }
        }   
        public bool UpdateProduct(Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying update Product {name}.", product.Name);
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public bool DeleteProduct(Product product) {
            try
            {
                _context.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying deleted Product {name}.", product.Name);
                throw new InternalServerErrorException(exception.Message);
            }
        }
    }
}
