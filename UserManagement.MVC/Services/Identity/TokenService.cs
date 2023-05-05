using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using UserManagement.MVC.Models;
using UserManagement.MVC.Extensions;
using System.Collections.Generic;
using UserManagement.MVC.Services.Identity;
using Microsoft.Extensions.Configuration;

namespace UserManagement.Web.Services.Identity
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(ApplicationUser user, List<IdentityRole> roles)
        {
            var token = user
                .CreateClaims(roles)
                .CreateJwtToken(_configuration);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}