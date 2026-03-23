using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Domain.Entities.Users
{
    public class RoleApp: IdentityRole<string>
    {
        [NotMapped]
        public ICollection<UserRoleApp>? UserRoles { get; set; }
    }
}
