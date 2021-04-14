using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Mediator.Interfaces;
using MarsRover.Infrastructure.Vehicle;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MarsRover.Infrastructure.Geography.Interfaces;

namespace MarsRover.Infrastructure.Mediator
{
    public class RoverMediator : IMediator<IRover>
    {
        public IPlateau Plateau { get; set; }

        private static readonly object _roverLock = new();
        public RoverMediator(IPlateau plateau)
        {
            Plateau = plateau;
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            throw new NotImplementedException();
        }


        public void Send(IRover rover, IEnumerable<ICommand> commands)
        {
            lock (_roverLock)
            {
                if (Plateau.IsRoverOn(rover))
                {
                    foreach (var command in commands)
                    {
                        command.Run();
                    }
                }
                else
                    throw new Exception("Rover in not on plateu");
            }
        }
    }

}
