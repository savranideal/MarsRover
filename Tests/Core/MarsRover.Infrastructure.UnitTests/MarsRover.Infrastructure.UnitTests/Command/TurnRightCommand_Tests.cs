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
    public class TurnRightCommand_Tests
    {
        [Fact]
        public void Run_Should()
        {
            Mock<IRover> roverMock = new Mock<IRover>();
            Rotate rotate = Rotate.Half;
            Point roverPoint = new Point(1, 2);
            roverMock.SetupGet(c => c.Point).Returns(roverPoint);
            roverMock.Setup(c => c.TurnRight(rotate)).Returns(roverPoint).Verifiable();
            ICommand turnRightCommand = new TurnRightCommand(roverMock.Object, rotate);

            turnRightCommand.Run();

            roverMock.Verify(c => c.TurnRight(rotate));

            roverMock.Object.Point.X.Should().Be(1);
            roverMock.Object.Point.Y.Should().Be(2);
        }
    }
}
