namespace OfficeReservationService.Contracts.Requests
{
    public class SeatingDto
    {
        public int CompanySeatingId { get; set; }
        public string? Description { get; set; }
        public bool IsOccupied { get; set; }
    }
}
