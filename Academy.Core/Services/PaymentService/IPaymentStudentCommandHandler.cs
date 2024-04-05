using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services.PaymentService
{
    public interface IPaymentStudentCommandHandler
    {
        Task<bool> Handle(IPaymentStudentCommand request, CancellationToken cancellationToken);
    }
}
