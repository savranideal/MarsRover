using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Geography.Interfaces;

namespace MarsRover.Infrastructure.Vehicle
{
    public interface IMoveable
    { 
        Point Move();
    }
}
