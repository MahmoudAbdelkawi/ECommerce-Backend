using Microsoft.AspNetCore.Identity;


namespace ECommerce.Domain.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserVerificationCodes> UserVerificationCodes { get; set; }
    }
}
