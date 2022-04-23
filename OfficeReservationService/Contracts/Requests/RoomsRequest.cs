namespace OfficeReservationService.Contracts.Requests
{
    public class RoomsRequest
    {
        public Guid CompanyId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
