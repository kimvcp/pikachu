using System;
using System.Threading.Tasks;

namespace Agoda.Pikachu.Api.Property
{
    public class HotelPropertyService : IHotelPropertyService
    {
        private readonly IBlackListRepository _blackListRepository;
        private readonly IPropertyRepository _propertyRepository;

        public HotelPropertyService(IBlackListRepository blackListRepository, 
            IPropertyRepository propertyRepository)
        {
            _blackListRepository = blackListRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<PropertyModel> GetProperty(int id)
        {
            var result = await _propertyRepository.GetPropertyDto(id);

            if (_blackListRepository.GetListOfBlackListedProperties().Contains(result.PropertyId))
            {
                throw new Exception("Property has been blacklisted");
            }

            return PropertyModel.From(result);
        }
    }
}