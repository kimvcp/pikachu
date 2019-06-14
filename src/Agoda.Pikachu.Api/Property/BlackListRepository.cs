using System.Collections.Generic;

namespace Agoda.Pikachu.Api.Property
{
    public class BlackListRepository : IBlackListRepository
    {
        public List<int> GetListOfBlackListedProperties()
        {
            return new List<int> {1, 2, 3, 4};
        }
    }
}