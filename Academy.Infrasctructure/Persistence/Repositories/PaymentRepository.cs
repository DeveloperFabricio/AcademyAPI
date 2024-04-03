using Academy.Core.Entities;
using Academy.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Infrasctructure.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _appDbContext;

        public PaymentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Cancel(Payment payment)
        {
            payment.Cancel();
            _appDbContext.Payments.Update(payment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Finish(Payment payment)
        {
            payment.Finish();
            _appDbContext.Payments.Update(payment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task SetPaymentPending(Payment payment)
        {
            payment.SetPaymentPending();
            _appDbContext.Payments.Update(payment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Start(Payment payment)
        {
            payment.Start();
            _appDbContext.Payments.Update(payment);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Payment payment)
        {
            _appDbContext.Payments.Update(payment);
            await _appDbContext.SaveChangesAsync();
        }

        async Task<Payment> IPaymentRepository.GetByIdAsync(int id)
        {
            return await _appDbContext.Payments.SingleOrDefaultAsync(s => s.Id == id);
        }
    
    }
}
