using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly SmtpSettings _smptSettings;
        public EmailSenderService(IOptions<SmtpSettings> smtpSettings)
        {
            _smptSettings = smtpSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest request)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smptSettings.SenderName, _smptSettings.SenderEmail));
                message.To.Add(new MailboxAddress("", request.Email));
                message.Subject = request.Subject;
                message.Body = new TextPart("html") { Text = request.Body };

                using (var client = new SmtpClient())
                {

                    await client.ConnectAsync(_smptSettings.Server);
                    await client.AuthenticateAsync(_smptSettings.UserName, _smptSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

    }
}
