using Academy.Core.Entities;
using Academy.Core.Enums;

namespace Academy.UnitTests.CoreEntities
{
    public class InstructorTest
    {
        [Fact]
        public void TestConstructor()
        {
            int id = 1;
            string name = "Fabricio";
            SpecializationEnum specialization = SpecializationEnum.Yoga;
            string avaibility = "Monday, Wednesday, Friday";
            string description = "Experienced yoga instructor";
            string location = "São Paulo";

            var instructor = new Instructor(id, name, "email@example.com", "password", specialization, avaibility, description, location, "role");

            Assert.Equal(id, instructor.Id);
            Assert.Equal(name, instructor.Name);
            Assert.Equal(specialization, instructor.Specialization);
            Assert.Equal(avaibility, instructor.Availability);
            Assert.Equal(description, instructor.Description);
            Assert.Equal(location, instructor.Location);
        }
    }
}
