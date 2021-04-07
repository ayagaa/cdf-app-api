using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Models.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(ApplicationData application, string subject, string message);
    }
}
