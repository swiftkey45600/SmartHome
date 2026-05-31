namespace SmartHomeMVP
{
    public class CommandScheduler
    {
        private readonly List<ICommand> _commands = new List<ICommand>();
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void ScheduleCommand(ICommand command) => _commands.Add(command);

        public void ExecuteCommands()
        {
            foreach (var cmd in _commands)
            {
                cmd.Execute();
                _history.Push(cmd);
            }
            _commands.Clear();
        }

        public void UndoLastCommand()
        {
            if (_history.Count > 0)
                _history.Pop().UnExecute();
            else
                Console.WriteLine("No commands to undo.");
        }
    }
}
