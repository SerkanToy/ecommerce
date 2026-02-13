using System.Security.Claims;

namespace ecommerce.api.Domain.Authorization
{
    public class CreateToken
    {
        public object Token(List<Claim> claims, DateTime expiration)
        {
            return "token";
        }
    }
}
