using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Geography.Interfaces;

namespace MarsRover.Infrastructure.Vehicle
{
    public interface ITurnable : IVehicle
    {
        Point TurnLeft(Rotate rotate);
        Point TurnRight(Rotate rotate);
    }

}
