using ecommerce.api.Models.Users;

namespace ecommerce.api.Models
{
    public class UserAddress
    {
        public string Id { get; set; }
        public string UserAppId { get; set; }
        public UserApp UserApp { get; set; }
        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}
