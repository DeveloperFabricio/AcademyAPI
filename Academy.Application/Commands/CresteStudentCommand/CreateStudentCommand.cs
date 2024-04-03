using Academy.Core.Entities;
using Academy.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Commands.CresteStudentCommand
{
    public class CreateStudentCommand : IRequest<Unit>
    {
        public CreateStudentCommand(int id,
            string name,
            string age,
            SubscriptionPlanEnum subscriptionPlan,
            List<Payment> paymentHistory)

        {
            Id = id;
            Name = name;
            Age = age;
            SubscriptionPlan = subscriptionPlan;
            PaymentHistory = paymentHistory;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public SubscriptionPlanEnum SubscriptionPlan { get; set; }
        public List<Payment> PaymentHistory { get; set; }
    }
    
    
}
