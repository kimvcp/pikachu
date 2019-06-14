using System.Collections.Generic;

namespace Agoda.Pikachu.Api.Property
{
    public interface IBlackListRepository
    {
        List<int> GetListOfBlackListedProperties();
    }
}