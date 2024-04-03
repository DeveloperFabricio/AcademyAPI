using Academy.Core.Entities;
using Academy.Core.Enums;

namespace Academy.UnitTests.CoreEntities
{
    public class StudentTest
    {
        [Fact]
        public void TestConstructor()
        {

            int id = 1;
            string name = "Alice";
            string age = "25";
            SubscriptionPlanEnum subscriptionPlan = SubscriptionPlanEnum.Premium;
            var paymentHistory = new List<Payment>();


            var student = new Student(id, name, age, subscriptionPlan, paymentHistory);


            Assert.Equal(id, student.Id);
            Assert.Equal(name, student.Name);
            Assert.Equal(age, student.Age);
            Assert.Equal(subscriptionPlan, student.SubscriptionPlan);
            Assert.Equal(paymentHistory, student.PaymentHistory);
        }
    }
}
