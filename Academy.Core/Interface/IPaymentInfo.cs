using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Interface
{
    public interface IPaymentInfo
    {
        int IdStudent { get; }
        string CreditCardNumber { get; }
        string Cvv { get; }
        string ExpiresAt { get; }
        string FullName { get; }
        decimal Amount { get; }
    }
}
