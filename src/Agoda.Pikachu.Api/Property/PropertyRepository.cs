using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dapper;

namespace Agoda.Pikachu.Api.Property
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IDatabaseSettings _databaseSettings;

        public PropertyRepository(IDatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        private IDbConnection Connection => new SqlConnection(_databaseSettings.ExampleDbConnectionString);

        public async Task<PropertyDto> GetPropertyDto(int id)
        {
            using (IDbConnection conn = Connection) 
            {
                conn.Open();
                return (await conn.QueryAsync<PropertyDto>("SELECT * FROM Property WHERE PropertyId= @PropertyId", 
                    new { PropertyId = id }))
                    .AsList()
                    .FirstOrDefault();
            }
        }
    }
}