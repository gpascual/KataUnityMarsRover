using Application;
using Domain;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Application
{
    [TestFixture]
    [TestOf(typeof(CommandInterpreter))]
    public class CommandInterpreterTest
    {
        private CommandInterpreter commandInterpreter;
        private MarsRover marsRover;

        [SetUp]
        public void SetUp()
        {
            commandInterpreter = new CommandInterpreter();
        }

        [Test]
        public void Should()
        {
            marsRover = Substitute.For<MarsRover>();
            var commandSequence = new CommandSequence { new MoveForward(marsRover) };

            commandInterpreter.Execute(commandSequence);

            marsRover.Received().MoveForward();
        }
    }
}
