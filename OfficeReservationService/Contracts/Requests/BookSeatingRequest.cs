namespace OfficeReservationService.Contracts.Requests
{
    public class BookSeatingRequest
    {
        public Guid CompanyId { get; set; }
        public Guid RoomId { get; set; }
        public Guid SeatingId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
