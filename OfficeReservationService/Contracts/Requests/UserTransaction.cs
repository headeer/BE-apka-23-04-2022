namespace OfficeReservationService.Contracts.Requests
{
    public class UserTransaction
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
