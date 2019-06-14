using System.Threading.Tasks;

namespace Agoda.Pikachu.Api.Property
{
    public interface IPropertyRepository
    {
        Task<PropertyDto> GetPropertyDto(int id);
    }
}