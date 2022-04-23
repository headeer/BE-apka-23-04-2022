namespace OfficeReservationService.Contracts.Requests
{
    public class InvitationRequest
    {
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
    }
}
