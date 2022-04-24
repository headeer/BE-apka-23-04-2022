namespace OfficeReservationService.Contracts.Requests
{
    public class RegistrationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Role { get; set; } TEMP
        public string CompanyId { get; set; }
    }
}
