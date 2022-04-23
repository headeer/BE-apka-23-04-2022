using Microsoft.AspNetCore.Identity;

namespace OfficeReservationService.Contracts.Models
{
    public class AppUser : IdentityUser
    {
        public virtual Company Company { get; set; }
    }
}
