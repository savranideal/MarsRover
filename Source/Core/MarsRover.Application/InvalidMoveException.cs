using System;

namespace MarsRover.Infrastructure
{
    public class InvalidMoveException : Exception
    { 
        public InvalidMoveException(string message) : base(message)
        {

        }

    }
}
