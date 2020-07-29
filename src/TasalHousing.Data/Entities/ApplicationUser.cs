using Microsoft.AspNetCore.Identity;

namespace TasalHousing.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}