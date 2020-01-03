namespace SIS.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string BadRequestExecptionDefaultMessage =
            "The Request was malformed or contains unsupported elements.";

        public BadRequestException() 
            : this(BadRequestExecptionDefaultMessage)
        {
        }

        public BadRequestException(string name)
            : base(name)
        {
        }
    }
}
