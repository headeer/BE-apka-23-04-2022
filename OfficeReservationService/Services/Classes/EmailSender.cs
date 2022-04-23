using MimeKit;
using MailKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit.Text;
using System.Reflection;
using OfficeReservationService.Services.Interfaces;

namespace OfficeReservationService.Services.Classes
{
    public class EmailSender : IEmailSender
    {
        public async Task<string> Send(string receiver, string content)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ShareThoughtProject"));
            email.To.Add(MailboxAddress.Parse(receiver));
            email.Subject = "Confirm your email";
            email.Body = new TextPart(TextFormat.Html) { Text = content };

            using var client = new SmtpClient(new ProtocolLogger("smtp.log"));

            await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

            await client.AuthenticateAsync("officereservservice@gmail.com", "F1r$t4pp_R3$erv");

            var response = await client.SendAsync(email);

            await client.DisconnectAsync(true);
            return response;
        }

        private static async Task<string> CreateHtmlToSend(string userId, string token)
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Config\Files\confirmationEmail.html"); this can serve as storing nicely styled HTML inside project and using it by reflection
            string file = await File.ReadAllTextAsync(""); //path goes here

            string confirmationLink = $@"https://localhost:3000/activate/{userId}/{token}";
            var message = file.Replace("{TOKEN_LINK}", confirmationLink);
            return message;
        }
    }
}
