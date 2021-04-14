using MarsRover.Infrastructure.Vehicle;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MarsRover.Infrastructure.UnitTests")]
namespace MarsRover.Infrastructure.Command
{

    internal sealed class TurnRightCommand : ICommand
    {
        private readonly Rotate _rotate;
        private readonly ITurnable _rover;

        public TurnRightCommand(ITurnable rover, Rotate rotate)
        {
            _rotate = rotate;
            _rover = rover;
        }

        public void Run()
        {
            _rover.TurnRight(_rotate);
        }
    }
}
