using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class UserVerificationCodes : BaseEntity
    {
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddMinutes(5);
        public bool CanChangePassword { get; set; }
        public DateTime CanChangePasswordAvailability { get; set; }
        public string UserId { get; set; }
        public User Users { get; set; }
    }
}
