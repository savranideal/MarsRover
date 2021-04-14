using MarsRover.Infrastructure.Command;
using System.Diagnostics;
using System.Linq;
using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Geography.Interfaces;

namespace MarsRover.Infrastructure.Vehicle
{
    [DebuggerDisplay("{Direction}-({Point.X},{Point.Y})")]
    public class Rover : IRover
    {
        public string Name { get; }
        public Point Point { get; private set; }
        public IPlateau Plateau { get; }
        public Direction Direction { get; set; }

        public Rover(IPlateau plateau, Point point, string name, Direction direction)
        {
            Point = point;
            Name = name;
            Direction = direction;
            Plateau = plateau;
        }

        public Point Move()
        {
            int x = Point.X;
            int y = Point.Y;
            switch (Direction)
            {
                case Direction.North:
                    y += 1;
                    break;
                case Direction.South:
                    y -= 1;
                    break;
                case Direction.East:
                    x += 1;
                    break;
                case Direction.West:
                    x -= 1;
                    break;
            }

            Point currentPoint = new Point(x, y);
            if (Plateau.CheckPointIsEmpty(currentPoint))
            {
                Point = currentPoint;
            }
            
            return Point;
        }

        public Point TurnLeft(Rotate rotate)
        {
            Direction = Direction switch
            {
                Direction.North => Direction.West,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                Direction.West => Direction.South,
                _ => Direction
            };

            if (rotate == Rotate.Full)
                TurnLeft(Rotate.Half);
            return Point;

        }

        public Point TurnRight(Rotate rotate)
        {
            Direction = Direction switch
            {
                Direction.North => Direction.East,
                Direction.South => Direction.West,
                Direction.East => Direction.South,
                Direction.West => Direction.North,
                _ => Direction
            };

            if (rotate == Rotate.Full)
                TurnRight(Rotate.Half);
            return Point;
        }

        public override string ToString()
        {
            return $"{Point.X} {Point.Y} {Constants.Directions.First(c => c.Value == Direction).Key}";
        }
    }
}
