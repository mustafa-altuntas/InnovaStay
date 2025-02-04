using Microsoft.AspNetCore.Identity;

namespace InnovaStay.Entity.Concrete.Identities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? City { get; set; }
    }
}
