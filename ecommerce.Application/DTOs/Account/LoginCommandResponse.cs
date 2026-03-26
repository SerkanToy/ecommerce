using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Application.DTOs.Account
{
    public sealed class LoginCommandResponse(string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);
}
