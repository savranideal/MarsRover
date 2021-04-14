using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Infrastructure
{
    public static class Constants
    {
        public static readonly IReadOnlyDictionary<string, MoveType> MoveTypes = new ReadOnlyDictionary<string, MoveType>(new Dictionary<string, MoveType> {

            {"L",MoveType.Left },
            {"R",MoveType.Right},
            {"M",MoveType.Move }
        });
        public static readonly IReadOnlyDictionary<string, Direction> Directions = new ReadOnlyDictionary<string, Direction>(new Dictionary<string, Direction> {

            {"N",Direction.North },
            {"S",Direction.South},
            {"E",Direction.East },
            {"W",Direction.West }
        });

    }
}
