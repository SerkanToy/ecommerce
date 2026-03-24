using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Infrastructure.Options
{
    public sealed class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
    }
}
