namespace SmartHomeMVP
{
    public class MacroCommand : ICommand
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command) => _commands.Add(command);

        public void Execute()
        {
            foreach (var cmd in _commands)
                cmd.Execute();
        }

        public void UnExecute()
        {
            for (int i = _commands.Count - 1; i >= 0; i--)
                _commands[i].UnExecute();
        }
    }
}
