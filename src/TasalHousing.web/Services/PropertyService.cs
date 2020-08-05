using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasalHousing.Data.DatabaseContexts.ApplicationDbContext;
using TasalHousing.Data.Entities;
using TasalHousing.web.Interfaces;
using TasalHousing.web.Models;

namespace TasalHousing.web.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _dbContext;

        public PropertyService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProperty(PropertyModel model)
        {
            var property = new Property
            {
                Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Description = model.Description,
                NumberOfRooms = model.NumberOfRooms,
                NumberOfBaths = model.NumberOfBaths,
                NumberOfToilets = model.NumberOfToilets,
                Address = model.Address,
                ContactPhoneNumber = model.ContactPhoneNumber,

            };

            await _dbContext.AddAsync(property);
            await _dbContext.SaveChangesAsync();
        }
    }
}
