using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services.PaymentService
{
    public interface IPaymentStudentCommand
    {
        int Id { get; }
        string CreditCardNumber { get; }
        string Cvv { get; }
        string ExpiresAt { get; }
        string FullName { get; }
    }
}
