using Academy.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(IPaymentInfo paymentInfo);
    }
}

