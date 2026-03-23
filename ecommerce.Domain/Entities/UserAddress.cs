

using ecommerce.Domain.Entities.Users;

namespace ecommerce.Domain.Entities
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
