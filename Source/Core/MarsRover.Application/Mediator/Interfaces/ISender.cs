﻿using System.Collections.Generic;
using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Vehicle;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Infrastructure.Mediator.Interfaces
{
    public interface ISender<in TVehicle> where TVehicle : IVehicle
    {
        void Send(TVehicle rover, IEnumerable<ICommand> commands);
    }
}