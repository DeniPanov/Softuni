namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public string Read(string args)
        {
            string[] tokens = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = tokens[0] + COMMAND_POSTFIX;

            string[] commandArgs = tokens
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            Type typeToCreate = types
                .FirstOrDefault(t => t.Name == commandName);

            object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
