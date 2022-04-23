namespace OfficeReservationService.Contracts.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsWorkSpaceRoom { get; set; }
        public virtual List<Seating> Seatings { get; set; } = new List<Seating>();
        public virtual Company Company { get; set; }
    }
}
