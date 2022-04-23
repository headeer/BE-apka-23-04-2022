namespace OfficeReservationService.Contracts.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        List<Seating> Seatings { get; set; } = new List<Seating>();
    }
}
