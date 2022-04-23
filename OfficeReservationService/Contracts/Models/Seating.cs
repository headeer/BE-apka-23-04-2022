namespace OfficeReservationService.Contracts.Models
{
    public class Seating
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public bool IsOccupied { get; set; }
        public virtual Room Room { get; set; }
    }
}
