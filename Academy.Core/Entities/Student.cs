using Academy.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Entities
{
    public class Student
    {
        public Student(int id,
            string name,
            string age,
            SubscriptionPlanEnum subscriptionPlan,
            List<Payment> paymentHistory)

        {
            Id = id;
            Name = name;
            Age = age;
            SubscriptionPlan = subscriptionPlan;
            PaymentHistory = new List<Payment>();
        }

        public Student()
        {
            PaymentHistory = new List<Payment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public SubscriptionPlanEnum SubscriptionPlan { get; set; }
        [NotMapped]
        public List<Payment> PaymentHistory { get; set; }
    }
}
