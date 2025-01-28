namespace Tests.Domain
{
    using NUnit.Framework;
    using NSubstitute;

    public interface ICalculator {
        int Add(int a, int b);
    }

    public class NSubstituteTest {
        [Test]
        public void TestMock() {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);

            Assert.AreEqual(3, calculator.Add(1, 2));
        }
    }
}