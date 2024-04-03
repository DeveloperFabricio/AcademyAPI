using Academy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Entities
{
    public class Payment
    {
        public int Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public PaymentsStatusEnum Status { get; private set; }
        public string Description { get; private set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Payment()
        {
            CreatedAt = DateTime.Now;
            Status = PaymentsStatusEnum.Created;
        }

        public void Cancel()
        {
            if (Status == PaymentsStatusEnum.InProgress || Status == PaymentsStatusEnum.Created)
            {
                Status = PaymentsStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if (Status == PaymentsStatusEnum.Created)
            {
                Status = PaymentsStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Finish()
        {
            if (Status == PaymentsStatusEnum.PaymentPending)
            {
                Status = PaymentsStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void SetPaymentPending()
        {
            Status = PaymentsStatusEnum.PaymentPending;
            FinishedAt = null;
        }
    }
}
