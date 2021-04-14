using MarsRover.Infrastructure.Vehicle;

namespace MarsRover.Infrastructure.Geography.Interfaces
{
    public interface IPlateau : ILand
    {

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        void DeployRover(IRover rover);
        bool IsRoverOn(IRover rover);

        bool CheckPointIsEmpty(Point point);
        bool Contains(Point point);
    }
}
