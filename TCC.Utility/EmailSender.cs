using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TCC.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions _emailOptions;

        public EmailSender(IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(subject, htmlMessage, email);
        }

        private async Task Execute(string subject, string htmlMessage, string email)
        {
            var sender = new SmtpSender(() => new SmtpClient(_emailOptions.SmtpClient)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = _emailOptions.SmtpPort,
                Credentials = new NetworkCredential() { UserName = _emailOptions.SmtpUsername, Password = _emailOptions.SmtpPassword },
            });

            Email.DefaultSender = sender;

            var sendmail = await Email
                .From(_emailOptions.SmtpUsername)
                .To(email)
                .Subject(subject)
                .Body(htmlMessage)
                .SendAsync();
        }
    }
}
