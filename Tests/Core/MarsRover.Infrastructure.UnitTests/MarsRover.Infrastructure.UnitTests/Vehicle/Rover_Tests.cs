using System.Linq;
using FluentAssertions;
using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Geography.Interfaces;
using MarsRover.Infrastructure.Vehicle;
using Moq;
using Xunit;

namespace MarsRover.Infrastructure.UnitTests.Vehicle
{
    // ReSharper disable once InconsistentNaming
    public class Rover_Tests
    {
        [Theory]
        [InlineData(Direction.North, 6, true)]
        [InlineData(Direction.East, 5, false)]
        [InlineData(Direction.West, 3, false)]
        [InlineData(Direction.South, 4, true)]
        public void Move_Should(Direction direction, int excepted, bool isY)
        {
            int x = 4;
            int y = 5;
            Mock<IPlateau> plateauMock = new Mock<IPlateau>();
            Point roverPoint = new Point(x, y);
            Point roverNexPoint = new Point(isY ? x : excepted, isY ? excepted : y);
            plateauMock.Setup(c => c.CheckPointIsEmpty(roverNexPoint)).Returns(true).Verifiable();
            plateauMock.Setup(c => c.Contains(roverNexPoint)).Returns(true).Verifiable();

            IRover rover = new Rover(plateauMock.Object, roverPoint, "rover_1", direction);
            Point output = rover.Move();

            output.Should().Be(roverNexPoint);
            rover.Name.Should().NotBeNullOrEmpty();
            rover.ToString().Should().Be($"{roverNexPoint} {Constants.Directions.First(c => c.Value == direction).Key}");
            plateauMock.Verify(c => c.CheckPointIsEmpty(roverNexPoint));
        }

        [Theory]
        [InlineData(Rotate.Half,Direction.North, Direction.West)]
        [InlineData(Rotate.Half,Direction.East, Direction.North)]
        [InlineData(Rotate.Half,Direction.South, Direction.East)]
        [InlineData(Rotate.Half,Direction.West, Direction.South)]
        [InlineData(Rotate.Full,Direction.North, Direction.South)]
        [InlineData(Rotate.Full,Direction.East, Direction.West)]
        [InlineData(Rotate.Full,Direction.South, Direction.North)]
        [InlineData(Rotate.Full,Direction.West, Direction.East)] 
        public void TurnLeft_Should(Rotate rotate,Direction currenDirection,Direction exceptedDirection)
        {
            int x = 4;
            int y = 5;
            Mock<IPlateau> plateauMock = new Mock<IPlateau>();
            Point roverPoint = new Point(x, y);  
            IRover rover = new Rover(plateauMock.Object, roverPoint, "rover_1", currenDirection);
            Point output = rover.TurnLeft(rotate);


            output.Should().Be(roverPoint);
            rover.Direction.Should().Be(exceptedDirection);
            rover.Name.Should().NotBeNullOrEmpty();
            rover.ToString().Should().Be($"{output} {Constants.Directions.First(c => c.Value == exceptedDirection).Key}");
        }
        [Theory]
        [InlineData(Rotate.Half,Direction.North, Direction.East)]
        [InlineData(Rotate.Half,Direction.East, Direction.South)]
        [InlineData(Rotate.Half,Direction.South, Direction.West)]
        [InlineData(Rotate.Half,Direction.West, Direction.North)]
        [InlineData(Rotate.Full,Direction.North, Direction.South)]
        [InlineData(Rotate.Full,Direction.East, Direction.West)]
        [InlineData(Rotate.Full,Direction.South, Direction.North)]
        [InlineData(Rotate.Full,Direction.West, Direction.East)] 
        public void TurnRight_Should(Rotate rotate,Direction currenDirection,Direction exceptedDirection)
        {
            int x = 4;
            int y = 5;
            Mock<IPlateau> plateauMock = new Mock<IPlateau>();
            Point roverPoint = new Point(x, y);  
            IRover rover = new Rover(plateauMock.Object, roverPoint, "rover_1", currenDirection);
            Point output = rover.TurnRight(rotate);


            output.Should().Be(roverPoint);
            rover.Direction.Should().Be(exceptedDirection);
            rover.Name.Should().NotBeNullOrEmpty();
            rover.ToString().Should().Be($"{output} {Constants.Directions.First(c => c.Value == exceptedDirection).Key}");
        }
    }
}
