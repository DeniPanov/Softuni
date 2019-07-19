namespace P04_Telephony.Exceptions
{
    using System;

    public class InvalidPhoneNumberException : Exception
    {
        private const string INVALID_PHONE_NUMBER_EXCEPTION = "Invalid number!";
        public InvalidPhoneNumberException()
            : base(INVALID_PHONE_NUMBER_EXCEPTION)
        {
        }

        public InvalidPhoneNumberException(string message)
            : base(message)
        {
        }
    }
}
