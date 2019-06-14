namespace Agoda.Pikachu.Api.Property
{
    public class PropertyModel
    {
        public string PropertyName { get; set; }
        public string PropertyAddressFull { get; set; }
        public int PropertyId { get; set; }

        public static PropertyModel From(PropertyDto result)
        { 
            return new PropertyModel
            {
                PropertyId = result.PropertyId,
                PropertyName = result.PropertyName,
                PropertyAddressFull = $"{result.PropertyAddressLine1}\n{result.PropertyAddressLine2}\n{result.PropertyAddressCountry}"
            };

        }
    }
}