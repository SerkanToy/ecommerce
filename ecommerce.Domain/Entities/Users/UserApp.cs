using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Domain.Entities.Users
{
    public class UserApp : IdentityUser<string>
    {
        public UserApp()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? TCNo { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenExpireDate { get; set; }
        [NotMapped]
        public ICollection<UserRoleApp>? UserRoles { get; set; }
        public ICollection<UserAddress>? UserAddress { get; set; }

    }
}
