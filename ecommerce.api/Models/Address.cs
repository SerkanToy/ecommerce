using System.Diagnostics.Metrics;

namespace ecommerce.api.Models
{
    public class Address
    {
        public Address()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }
        public ICollection<UserAddress>? UserAddress { get; set; }
        public string? PostalCode { get; set; } = null;
    } 
}
