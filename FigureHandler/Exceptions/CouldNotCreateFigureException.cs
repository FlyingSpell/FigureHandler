using System;

namespace FigureHandler.Exceptions
{
    class CouldNotCreateFigureException : Exception
    {
        public CouldNotCreateFigureException(string message) : base(message)
        {
        }
    }
}
