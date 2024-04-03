using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email, string subject, string message);
    }
}
