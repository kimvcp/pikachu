using System.Threading.Tasks;

namespace Agoda.Pikachu.Api.Property
{
    public interface IHotelPropertyService
    {
        Task<PropertyModel> GetProperty(int id);
    }
}