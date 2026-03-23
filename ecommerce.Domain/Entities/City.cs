using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Domain.Entities
{
    public class City
    {
        public City()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Country")]
        public string? CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<Address>? Address { get; set; }
    }
}
