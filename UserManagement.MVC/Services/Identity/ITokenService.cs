using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Services.Identity
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, List<IdentityRole> role);
    }
}

