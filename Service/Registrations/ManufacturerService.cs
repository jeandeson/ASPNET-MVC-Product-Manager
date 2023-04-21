using Model.Errors;
using Model.Registrations;
using Model.Tables;
using Persistence.DAL.Registrations;
using Persistence.DAL.Tables;
using System;
using System.Linq;
using System.Net;

namespace Service.Tables
{
    public class ManufacturerService
    {
        private readonly ManufacturerDAL _manufacturerDAL;
        public ManufacturerService(ManufacturerDAL manufacturerDAL)
        {
            _manufacturerDAL = manufacturerDAL;
        }
        public IOrderedQueryable<Manufacturer> GetManufacturersOrderedByName()
        {
            IOrderedQueryable<Manufacturer>? manufacturers = _manufacturerDAL.GetManufacturersOrderedByName();
            if (manufacturers == null)
            {
                throw new NotFoundException("no manufacturers were found.");
            }
            return manufacturers;
        }
        public Manufacturer GetManufacturerById(long? id)
        {
            if (id == null || id <= 0)
            {
                throw new BadRequestException($"id cannot be null or less than or equal to zero, id: {id}");
            }
            Manufacturer? manufacturer = _manufacturerDAL.GetManufacturerById(id.Value);
            if (manufacturer == null)
            {
                throw new NotFoundException($"object with {id} was not found on database");
            }
            return manufacturer;
        }
        public void InsertManufacturer(Manufacturer manufacturer)
        {
            bool isInserted = _manufacturerDAL.InsertManufacturer(manufacturer);
            if (!isInserted)
            {
                throw new BadRequestException($"object {manufacturer.Name} was not inserted into database");
            }
        }
        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            bool isUpdated = _manufacturerDAL.UpdateManufacturer(manufacturer);
            if (!isUpdated)
            {
                throw new BadRequestException($"object {manufacturer.Name} was not updated into database");
            }
        }
        public void DeleteManufacturer(long? id)
        {
            Manufacturer manufacturer = GetManufacturerById(id);
            bool isDeleted = _manufacturerDAL.DeleteManufacturer(manufacturer);
            if (!isDeleted)
            {
                throw new BadRequestException($"object with {id} was not deleted from database");
            }
        }
    }
}
