namespace P04_Telephony
{
    using System;

    using P04_Telephony.Exceptions;
    public class StartUp
    {
        public static void Main()
        {
            string[] numbersToCall = Console.ReadLine()
                .Split(' '/*, StringSplitOptions.RemoveEmptyEntries*/);

            string[] urlsToBrowse = Console.ReadLine()
               .Split(' '/*, StringSplitOptions.RemoveEmptyEntries*/);

            SmartPhone smartPhone = new SmartPhone();

            CallingAPhoneNumbers(numbersToCall, smartPhone);
            BrowsingWebSites(urlsToBrowse, smartPhone);
        }

        private static void BrowsingWebSites(string[] urlsToBrowse, SmartPhone smartPhone)
        {
            for (int i = 0; i < urlsToBrowse.Length; i++)
            {
                var currentUrl = urlsToBrowse[i];

                try
                {
                    Console.WriteLine(smartPhone.Browse(currentUrl));
                }

                catch (InvalidURLException iurle)
                {
                    Console.WriteLine(iurle.Message);
                }
            }
        }

        private static void CallingAPhoneNumbers(string[] numbersToCall, SmartPhone smartPhone)
        {
            for (int i = 0; i < numbersToCall.Length; i++)
            {
                var currentNumber = numbersToCall[i];

                try
                {
                    Console.WriteLine(smartPhone.Call(currentNumber));
                }

                catch (InvalidPhoneNumberException ine)
                {
                    Console.WriteLine(ine.Message);
                }
            }
        }
    }
}
