using Microsoft.AspNetCore.Mvc;
using OfficeReservationService.Services.Interfaces;

namespace OfficeReservationService.Controllers
{
    public class EmailSendingTestController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public EmailSendingTestController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("/email/test")]
        public async Task<IActionResult> SendEmail([FromBody] string content)
        {
            return Ok(await _emailSender.Send("kubag98@hotmail.com", content));
        }
    }
}
