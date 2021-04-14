using FluentAssertions;
using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Vehicle;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.Infrastructure.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class CommandParser_Tests
    {
        [Theory]
        [InlineData('L', MoveType.Left)]
        [InlineData('R', MoveType.Right)]
        [InlineData('M', MoveType.Move)]
        public void ConvertLetterToMoveType_ShouldConvert(char inputCommand, MoveType excepted)
        {
            MoveType output = CommandParser.ConvertLetterToMoveType(inputCommand);
            output.Should().Be(excepted);
        }
        [Theory]
        [InlineData('K')]
        [InlineData('S')]
        [InlineData('Y')]
        public void ConvertLetterToMoveType_Should_ThrowException(char inputCommand)
        {
            Func<MoveType> convertFunction = () => CommandParser.ConvertLetterToMoveType(inputCommand);
            convertFunction.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData(MoveType.Left, typeof(TurnLeftCommand))]
        [InlineData(MoveType.Right, typeof(TurnRightCommand))]
        [InlineData(MoveType.Move, typeof(MoveCommand))]
        public void CreateRoverCommand_Should_CreateCommand(MoveType moveType, Type expected)
        {
            Mock<IRover> rover = new Mock<IRover>();

            ICommand output = CommandParser.CreateRoverCommand(rover.Object, moveType);
            output.Should().NotBeNull();
            output.Should().BeOfType(expected);
        }

        [Theory]
        [InlineData("LMLMLMLMM")]
        [InlineData("MMRMMRMRRM")]
        public void CreateRoverCommandsFromText_Should_Convert(string commandInput)
        {
            Mock<IRover> rover = new Mock<IRover>();
            IEnumerable<ICommand> commands = CommandParser.CreateRoverCommandsFromText(commandInput, rover.Object);
            commands.Should().NotBeNull();
            commands.Should().HaveCount(commandInput.Length);
            commands.Where(c => c is TurnLeftCommand).Should().ContainItemsAssignableTo<TurnLeftCommand>().And
                .HaveCount(commandInput.Count(c => c == 'L'));
            commands.Where(c => c is MoveCommand).Should().ContainItemsAssignableTo<MoveCommand>().And
                .HaveCount(commandInput.Count(c => c == 'M'));
            commands.Where(c => c is TurnRightCommand).Should().ContainItemsAssignableTo<TurnRightCommand>().And
                .HaveCount(commandInput.Count(c => c == 'R'));
        }
    }
}
