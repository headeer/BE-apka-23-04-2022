using Microsoft.AspNetCore.Identity;

namespace OfficeReservationService.Contracts.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public List<IdentityUser> Admins { get; set; }
        public List<IdentityUser>? Users { get; set; }
        public List <Room> Rooms { get; set; }

    }
}
