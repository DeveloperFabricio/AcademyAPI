using Academy.Core.Entities;
using Academy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services.StudentService
{
    public interface ICreateStudentCommand
    {
        int Id { get; }
        string Name { get; }
        string Age { get; }
        SubscriptionPlanEnum SubscriptionPlan { get; }
        List<Payment> PaymentHistory { get; }
    }
}
