using Academy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Interface
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByIdAsync(int id);
        Task Start(Payment payment);
        Task Finish(Payment payment);
        Task Cancel(Payment payment);
        Task Update(Payment payment);
        Task SetPaymentPending(Payment payment);
        Task SaveChangesAsync();
    }
}
