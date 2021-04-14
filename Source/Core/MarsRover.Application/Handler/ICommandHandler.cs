using MarsRover.Infrastructure.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Infrastructure.Handler
{
    public interface ICommandHandler<TCommand,TVehicle> where TCommand:ICommand
    {
    }
}
