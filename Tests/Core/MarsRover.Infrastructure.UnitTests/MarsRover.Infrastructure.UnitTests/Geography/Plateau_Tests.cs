using FluentAssertions;
using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Vehicle;
using Moq;
using System;
using MarsRover.Infrastructure.Geography.Interfaces;
using Xunit;

namespace MarsRover.Infrastructure.UnitTests.Geography
{
    // ReSharper disable once InconsistentNaming
    public class Plateau_Tests
    {

        [Fact]
        public void DeployRover_ShouldDeploy()
        {
            Mock<IRover> roverMock = new Mock<IRover>();

            roverMock.SetupGet(c => c.Name).Returns("rover1");
            IPlateau plateau = new Plateau("plateau1", new Point(0, 0), new Point(5, 5));
            plateau.DeployRover(roverMock.Object);
            bool isRoverOn = plateau.IsRoverOn(roverMock.Object);
            isRoverOn.Should().BeTrue();
        }

        [Fact]
        public void DeployRover_ShouldNotDeploy()
        { 
            Mock<IRover> roverMock = new Mock<IRover>(); 

            roverMock.SetupGet(c => c.Name).Returns(string.Empty);
            IPlateau plateau = new Plateau("plateau1", new Point(0, 0), new Point(5, 5));
            Action deployAction = () => plateau.DeployRover(roverMock.Object);
            deployAction.Should().Throw<Exception>();

        }

        [Fact]
        public void Contains_Should_True()
        {
            IPlateau plateau = new Plateau("plateau", new Point(0, 0), new Point(5, 5));
            bool output=plateau.Contains(new Point(1, 2));
            bool output2=plateau.Contains(new Point(0, 0));
            bool output3=plateau.Contains(new Point(4, 2));
            plateau.Name.Should().NotBeNullOrEmpty();
            output.Should().BeTrue();
            output2.Should().BeTrue();
            output3.Should().BeTrue();

        }
        [Fact]
        public void Contains_Should_False()
        {
            IPlateau plateau = new Plateau("plateau", new Point(0, 0), new Point(5, 5));
            bool output=plateau.Contains(new Point(6, 0));
            bool output2=plateau.Contains(new Point(-1, 0));
            bool output3=plateau.Contains(new Point(9, 5));
            plateau.Name.Should().NotBeNullOrEmpty();
            output.Should().BeFalse();
            output2.Should().BeFalse();
            output3.Should().BeFalse();

        }
        [Fact]
        public void CheckPointIsEmpty_EmptyPlato_ShouldTrue()
        {
            IPlateau plateau = new Plateau("plateau", new Point(0, 0), new Point(5, 5));
            plateau.DeployRover(new Rover(plateau,new Point(4,3),"rover_1",Direction.East));
            plateau.Name.Should().NotBeNullOrEmpty();
            plateau.CheckPointIsEmpty(new Point(0, 0)).Should().BeTrue();
            plateau.CheckPointIsEmpty(new Point(0, 1)).Should().BeTrue();
            plateau.CheckPointIsEmpty(new Point(5, 5)).Should().BeTrue();
            plateau.CheckPointIsEmpty(new Point(2, 4)).Should().BeTrue();
        }

        [Fact]
        public void CheckPointIsEmpty_NotIncludedPoint_ShouldFalse()
        {
            IPlateau plateau = new Plateau("plateau", new Point(0, 0), new Point(5, 5));
            plateau.DeployRover(new Rover(plateau, new Point(1, 1), "rover_1", Direction.East));
            plateau.Name.Should().NotBeNullOrEmpty();
            plateau.CheckPointIsEmpty(new Point(9, 0)).Should().BeFalse();
            plateau.CheckPointIsEmpty(new Point(1, 1)).Should().BeFalse();
            plateau.CheckPointIsEmpty(new Point(6, 5)).Should().BeFalse();
            plateau.CheckPointIsEmpty(new Point(2, 7)).Should().BeFalse();
        }
    }
}
