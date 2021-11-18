using NUnit.Framework;
using SimpleCalculator;

namespace SimpleCalculator.Test
{

    [TestFixture]
    public class MyUnitTest
    {
        [Test]
        public void TestRegularUseCaseWithSmallNumbers()
        {
            //Arrange:
            SimpleCalculator.Program.SimpleCalculator simpleCalculator = new SimpleCalculator.Program.SimpleCalculator();
            //Act:
            int result = simpleCalculator.Add(1, 2);
            //Assert:
            Assert.AreEqual(3, result);
        }
    }
}