using FluentAssertions;
using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Geography.Interfaces;
using MarsRover.Infrastructure.Vehicle;
using Moq;
using Xunit;

namespace MarsRover.Infrastructure.UnitTests.Command
{
    // ReSharper disable once InconsistentNaming
    public class TurnLeftCommand_Tests
    {
        [Fact]
        public void Run_Should()
        {
            Mock<IRover> roverMock = new Mock<IRover>();
            Rotate rotate = Rotate.Half;
            Point roverPoint = new Point(1, 2);
            roverMock.SetupGet(c => c.Point).Returns(roverPoint);
            roverMock.Setup(c => c.TurnLeft(rotate)).Returns(roverPoint).Verifiable();
            ICommand turnLeftCommand = new TurnLeftCommand(roverMock.Object, rotate);

            turnLeftCommand.Run();

            roverMock.Verify(c => c.TurnLeft(rotate));

            roverMock.Object.Point.X.Should().Be(1);
            roverMock.Object.Point.Y.Should().Be(2);
        }
    }
}
