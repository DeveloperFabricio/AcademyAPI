using Academy.Core.Entities;
using Academy.Core.Enums;

namespace Academy.UnitTests.CoreEntities
{
    public class SportTest
    {
        [Fact]
        public void TestConstructor()
        {

            int id = 1;
            string name = "Basketball";
            string description = "Team sport played on a rectangular court with hoops at each end.";
            DifficultLevelEnum difficulty = DifficultLevelEnum.Medium;


            var sport = new Sport(id, name, description, difficulty);


            Assert.Equal(id, sport.Id);
            Assert.Equal(name, sport.Name);
            Assert.Equal(description, sport.Description);
            Assert.Equal(difficulty, sport.DifficultLevel);
        }
    }
}
