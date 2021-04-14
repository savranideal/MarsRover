using MarsRover.Infrastructure.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Infrastructure.Geography.Interfaces;

namespace MarsRover.Infrastructure.Geography
{
    public class Plateau : IPlateau
    {
        private readonly IDictionary<string, IRover> _rovers;
        private const string OutputText = "Output:";
        public Plateau(string name, Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Name = name;
            _rovers = new Dictionary<string, IRover>();
        }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public string Name { get; set; }

        public void DeployRover(IRover rover)
        {
            if (string.IsNullOrEmpty(rover.Name))
                throw new Exception("Rover name is empty");
            _rovers[rover.Name] = rover;
        }
        public bool IsRoverOn(IRover rover)
        {
            return _rovers.ContainsKey(rover.Name);
        }

        public bool CheckPointIsEmpty(Point point)
        {
            return Contains(point) && _rovers.Values.All(c => c.Point != point);
        }

        public bool Contains(Point point)
        {
            return StartPoint.X <= point.X && point.X <= EndPoint.X && StartPoint.Y <= point.Y && point.Y <= EndPoint.Y;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(OutputText);
            builder.Append(Environment.NewLine);
            foreach (var (_, value) in _rovers)
            {
                builder.Append(value);
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}
