namespace OfficeReservationService.Services.Interfaces
{
    public interface IEmailSender
    {
        public Task<string> Send(string receiver, string content);
    }
}
