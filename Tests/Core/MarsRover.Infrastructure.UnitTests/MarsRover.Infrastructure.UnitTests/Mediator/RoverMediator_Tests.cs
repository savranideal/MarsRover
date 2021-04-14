using FluentAssertions;
using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Mediator;
using MarsRover.Infrastructure.Mediator.Interfaces;
using MarsRover.Infrastructure.Vehicle;
using Moq;
using System;
using System.Collections.Generic;
using MarsRover.Infrastructure.Geography.Interfaces;
using Xunit;

namespace MarsRover.Infrastructure.UnitTests.Mediator
{
    // ReSharper disable once InconsistentNaming
    public class RoverMediator_Tests
    {

        [Fact]
        public void Send_ShouldCommandRun()
        {
            Mock<IPlateau> plateauMock = new Mock<IPlateau>();
            Mock<IRover> roverMock = new Mock<IRover>();
            Mock<ICommand> commandMock = new Mock<ICommand>();
            plateauMock.Setup(c => c.IsRoverOn(roverMock.Object)).Returns(true).Verifiable();
            commandMock.Setup(c => c.Run()).Verifiable();
            IMediator mediator = new RoverMediator(plateauMock.Object);

            mediator.Send(roverMock.Object, new List<ICommand> { commandMock.Object });

            plateauMock.Verify(c => c.IsRoverOn(roverMock.Object));
            commandMock.Verify(c => c.Run());
        }

        [Fact]
        public void Send_ShouldNotRunCommand_ThrowException()
        {
            Mock<IPlateau> plateauMock = new Mock<IPlateau>();
            Mock<IRover> roverMock = new Mock<IRover>();
            Mock<ICommand> commandMock = new Mock<ICommand>();
            plateauMock.Setup(c => c.IsRoverOn(roverMock.Object)).Returns(false).Verifiable();

            IMediator mediator = new RoverMediator(plateauMock.Object);
            Action sendAction = () => mediator.Send(roverMock.Object, new List<ICommand> { commandMock.Object });

            sendAction.Should().Throw<Exception>();
            plateauMock.Verify(c => c.IsRoverOn(roverMock.Object));
        }
    }
}
