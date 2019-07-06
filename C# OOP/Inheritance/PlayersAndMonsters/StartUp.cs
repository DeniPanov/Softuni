using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Elf wizard = new Elf("myWizard", -1);
                System.Console.WriteLine(wizard);
            }

            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }            
        }
    }
}