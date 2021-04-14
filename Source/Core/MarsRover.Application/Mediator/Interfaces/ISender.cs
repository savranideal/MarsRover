using System.Collections.Generic;
using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Vehicle;

namespace MarsRover.Infrastructure.Mediator.Interfaces
{
    public interface ISender
    {
        void Send<TVehicle>(TVehicle rover, IEnumerable<ICommand> commands) where TVehicle : IRover;
    }
}
