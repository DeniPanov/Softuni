namespace P04_Telephony
{
    using System;
    using System.Linq;

    using P04_Telephony.Exceptions;
    using P04_Telephony.Interfaces;

    public class SmartPhone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            bool containsNumber = url.Any(c => char.IsDigit(c));

            if (containsNumber)
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            bool containsInvalidSymbols = !(phoneNumber.All(n => char.IsDigit(n)));

            if (containsInvalidSymbols)
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
