using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Models.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string destinationEmail, string subject, string message);
    }
}
