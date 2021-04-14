using MarsRover.Infrastructure.Vehicle;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MarsRover.Infrastructure.UnitTests")]
namespace MarsRover.Infrastructure.Command
{
    internal sealed class TurnLeftCommand : ICommand
    {
        private readonly Rotate _rotate;
        private readonly ITurnable _rover;

        public TurnLeftCommand(ITurnable rover, Rotate rotate)
        {
            _rotate = rotate;
            _rover = rover;
        }
        public void Run()
        {
            _rover.TurnLeft(_rotate);
        }
    }
}
