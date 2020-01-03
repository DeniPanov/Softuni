namespace SIS.HTTP.Exceptions
{
    using System;

    public class InternalServerErrorException : Exception
    {
        private const string InternalServerExecptionDefaultMessage =
            "The Server has encountered an error.";

        public InternalServerErrorException()
            : this(InternalServerExecptionDefaultMessage)
        {
        }

        public InternalServerErrorException(string name)
            : base()
        {
        }
    }
}
