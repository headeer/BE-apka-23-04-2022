namespace OfficeReservationService.Contracts.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public virtual List<AppUser>? Users { get; set; }
        public virtual List <Room> Rooms { get; set; }

    }
}
