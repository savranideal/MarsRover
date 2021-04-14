using MarsRover.Infrastructure.Vehicle;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MarsRover.Infrastructure.UnitTests")]
namespace MarsRover.Infrastructure.Command
{
    internal sealed class MoveCommand : ICommand
    {
        private readonly IMoveable _rover;
        public MoveCommand(IMoveable rover)  
        {
            _rover = rover;
        }

        public  void Run()
        {
            _rover.Move();
        }
    }
}
