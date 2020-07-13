using TasalHousing.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TasalHousing.Data.DatabaseContexts.AuthenticationDbContext
{

    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
    {
       public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
         : base(options)
       {

       }
    }
}