using Domain;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Domain
{
    public class MarsRoverTest
    {
        private MarsRover sut;
        private IMotor motor;

        [SetUp]
        public void Setup()
        {
            motor = Substitute.For<IMotor>();
            sut = new MarsRover(motor);
        }

        [Test]
        public void MoveForward()
        {
            sut.MoveForward();

            motor.Received(1).Forward(Arg.Is<int>(1));
        }
    }
}