using CDF.API.Models;
using CDF.API.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CDF.API.DataAccess
{
    public class AuthMessageSender : IEmailSender, ISmsSender
    {

        IConfiguration configuration = null;

        public AuthMessageSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task SendEmailAsync(ApplicationData application, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage(configuration["Email:email"], application.UserEmail, subject, message);

            mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Plain));
            mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Html));
            string.Format("From: {0}, To: {1}, smtp: {2}, password: {3}", configuration["Email:email"], application.UserEmail, configuration["Email:smtp"], configuration["Email:password"]);
            SmtpClient smtpClient = new SmtpClient(configuration["Email:smtp"], Convert.ToInt32(587));
            NetworkCredential credential = new NetworkCredential(configuration["Email:email"], configuration["Email:password"]);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = credential;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

            return Task.FromResult(0);
        }

        public Task SendSmsAsync(ApplicationData application, string message)
        {
            return Task.FromResult(0);
        }
    }
}
