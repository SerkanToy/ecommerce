using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ecommerce.api.Models.Users
{
    public class UserRoleApp: IdentityUserRole<string>
    {
        [NotMapped]
        public UserApp? User { get; set; }
        [NotMapped]
        public UserApp? Role { get; set; }
        public bool Expired { get; set; }
    }
}
