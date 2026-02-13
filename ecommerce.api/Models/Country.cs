namespace ecommerce.api.Models
{
    public class Country
    {
        public Country()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<City>? City { get; set; }
    }
}
