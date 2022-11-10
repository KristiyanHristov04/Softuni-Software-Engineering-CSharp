using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;



namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string input)
        {
            string[] tokens = input.Split();
            string command = tokens[0] + "Command";
            string[] value = tokens.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().First(x => x.Name == command);
            ICommand instance = Activator.CreateInstance(type) as ICommand;

            return instance.Execute(value);
        }
    }
}