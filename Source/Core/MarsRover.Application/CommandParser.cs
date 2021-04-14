using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Vehicle;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Infrastructure
{
    public static class CommandParser
    {
        public static MoveType ConvertLetterToMoveType(char letter)
        {
            return letter switch
            {
                'L' => MoveType.Left,
                'M' => MoveType.Move,
                'R' => MoveType.Right,
                _ => throw new InvalidMoveException($"{letter} is invalid move command.")
            };
        }

        public static ICommand CreateRoverCommand(IRover rover, MoveType moveType)
        {
            return moveType switch
            {
                MoveType.Left => new TurnLeftCommand(rover, Rotate.Half),
                MoveType.Right => new TurnRightCommand(rover, Rotate.Half),
                MoveType.Move => new MoveCommand(rover),
                _ => throw new InvalidMoveException($"{moveType} is invalid move command.")
            };
        }


        public static IEnumerable<ICommand> CreateRoverCommandsFromText(string commandText, IRover rover) => commandText
            .Trim().ToCharArray().Select(c => CreateRoverCommand(rover, ConvertLetterToMoveType(c)));
    }
}
