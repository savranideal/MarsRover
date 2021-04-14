using MarsRover.Infrastructure;
using MarsRover.Infrastructure.Command;
using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Mediator;
using MarsRover.Infrastructure.Mediator.Interfaces;
using MarsRover.Infrastructure.Vehicle;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarsRover.Infrastructure.Geography.Interfaces;

namespace MarsRover.Console
{
    public class Program
    {
        static void Main()
        {
            IPlateau plateu = new Plateau("plateau", new Point(), new Point(5, 5));
            ISender mediator = new RoverMediator(plateu);

            IRover rover1 = new Rover(plateu, new Point(1, 2), "rover1", Direction.North);
            IRover rover2 = new Rover(plateu, new Point(3, 3), "rover2", Direction.East);

            plateu.DeployRover(rover1);
            plateu.DeployRover(rover2);

            IEnumerable<ICommand> rover1Commands = CommandParser.CreateRoverCommandsFromText("LMLMLMLMM", rover1);
            IEnumerable<ICommand> rover2Commands = CommandParser.CreateRoverCommandsFromText("MMRMMRMRRM", rover2);

            //mediator.Send(rover1, rover1Commands);
            //mediator.Send(rover2, rover2Commands);

            IEnumerable<Task> deploys = new List<Task>
            {
                Task.Run(() => mediator.Send(rover1, rover1Commands)),
                Task.Run(() => mediator.Send(rover2, rover2Commands))
            };
            Task.WhenAll(deploys);
            System.Console.WriteLine("Test Input: \n5 5 \n1 2 N \nLMLMLMLMM \n3 3 E \nMMRMMRMRRM\n");
            System.Console.WriteLine("Expected Output:\n1 3 N\n5 1 E\n");
            System.Console.WriteLine(plateu.ToString());

            System.Console.ReadLine();
        }
    }
}
