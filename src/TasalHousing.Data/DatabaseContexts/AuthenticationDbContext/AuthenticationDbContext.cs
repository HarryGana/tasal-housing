using TasalHousing.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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