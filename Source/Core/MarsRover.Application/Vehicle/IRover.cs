using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Geography.Interfaces;

namespace MarsRover.Infrastructure.Vehicle
{
    public interface IRover : ITurnable, IMoveable
    {
        Point Point { get; }
        Direction Direction { get; set; }

    }
}
