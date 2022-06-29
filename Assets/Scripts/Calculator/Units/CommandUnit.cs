using System;
using System.Collections.Generic;

namespace Calculator.Units
{
    public class CommandUnit
    {
        private readonly Register _register;
        private readonly Dictionary<Type, Command> _commands;

        public CommandUnit(Register register, ICommandReader[] commands)
        {
            _register = register;
            _commands = RegisterCommands(commands);

            _register.OnCommandStarted += Run;
        }

        private Dictionary<Type, Command> RegisterCommands(ICommandReader[] commandsList)
        {
            Dictionary<Type, Command> commands = new Dictionary<Type, Command>();

            for (int i = 0; i < commandsList.Length; i++) 
                commands.Add(commandsList[i].Command.GetType(), commandsList[i].Command);

            return commands;
        }

        private void Run(Type commandType)
        {
            if (_commands.TryGetValue(commandType, out Command command))
            {
                command.Run();
                return;
            }

            throw new Exception($"Command of {commandType} not registered!");
        }
    }
}