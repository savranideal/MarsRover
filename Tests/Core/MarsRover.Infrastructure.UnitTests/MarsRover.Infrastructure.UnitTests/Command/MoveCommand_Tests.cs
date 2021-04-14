using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Geography.Interfaces;
using MarsRover.Infrastructure.Vehicle;
using Moq;
using Xunit;

namespace MarsRover.Infrastructure.UnitTests.Command
{
    // ReSharper disable once InconsistentNaming
    public class MoveCommand_Tests
    {
        [Fact]
        public void Run_Should()
        {
            Mock<IMoveable> roverMock = new Mock<IMoveable>(); 
            Point roverPoint = new Point(1, 2); 
            roverMock.Setup(c => c.Move()).Returns(roverPoint).Verifiable();
            ICommand moveCommand = new MoveCommand(roverMock.Object);

            moveCommand.Run();

            roverMock.Verify(c => c.Move());
             
        }
    }
}
