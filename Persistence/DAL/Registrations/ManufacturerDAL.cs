using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Errors;
using Model.Registrations;
using Persistence.Interfaces;

namespace Persistence.DAL.Tables
{
    public class ManufacturerDAL : IManufacturerDAL
    {
        private readonly EFContext _context;
        private readonly ILogger<ManufacturerDAL> _logger;
        public ManufacturerDAL(EFContext context, ILogger<ManufacturerDAL> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IOrderedQueryable<Manufacturer> GetManufacturersOrderedByName()
        {
            try
            {
                return _context.Manufacturers.OrderBy(c => c.Name);
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying get Get Manufacturers ordered by name.");
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public Manufacturer? GetManufacturerById(long id)
        {
            try
            {
                return _context.Manufacturers.Find(id);
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying get Manufacturer {id}.", id);
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public bool InsertManufacturer(Manufacturer manufacturer)
        {
            try
            {
                _context.Manufacturers.Add(manufacturer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying insert Manufacturer {name}.", manufacturer.Name);
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public bool UpdateManufacturer(Manufacturer manufacturer)
        {
            try
            {
                _context.Entry(manufacturer).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Fail trying update Manufacturer {name}.", manufacturer.Name);
                throw new InternalServerErrorException(exception.Message);
            }
        }
        public bool DeleteManufacturer(Manufacturer manufacturer)
        {
            try
            {
                _context.Manufacturers.Remove(manufacturer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception, "Manufacturer {name} was not deleted from database.", manufacturer.Name);
                throw new InternalServerErrorException(exception.Message);
            }
        }
    }
}
