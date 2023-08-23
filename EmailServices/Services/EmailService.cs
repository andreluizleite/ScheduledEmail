

namespace EmailServices.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to: {to}, Subject: {subject}, Body: {body}");
        }
    }
}
