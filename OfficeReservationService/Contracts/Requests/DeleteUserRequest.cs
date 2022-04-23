namespace OfficeReservationService.Contracts.Requests
{
    public class DeleteUserRequest
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
