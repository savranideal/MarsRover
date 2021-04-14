using System;
using MarsRover.Infrastructure.Geography.Interfaces;

namespace MarsRover.Infrastructure.Geography
{
    public struct Point : IEquatable<Point>
    {

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }
        public override bool Equals(object obj)
        {
            return obj is Point other && Equals(other);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Point first, Point second)
        {
            return Equals(first, second);
        }
        public static bool operator !=(Point first, Point second)
        {
            return !Equals(first, second);
        }
        public override string ToString() => $"{X} {Y}";
    }
}
