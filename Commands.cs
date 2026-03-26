namespace SmartHomeMVP
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }

    public class TurnOnCommand : ICommand
    {
		private Light light;

        public TurnOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
        public void UnExecute()
        {
            light.TurnOff();
        }
    }

    public class TurnOffCommand : ICommand
    {
		private Light light;

        public TurnOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
        }
        public void UnExecute()
        {
            light.TurnOn();
        }
    }
    
    public class SetTemperatureCommand : ICommand
    {
        private Thermostat thermostat;
        private int newTemperature;
        private int prevTemperature;

        public SetTemperatureCommand(Thermostat thermostat, int newTemperature)
        {
            this.thermostat = thermostat;
            this.newTemperature = newTemperature;
        }

        public void Execute()
        {
            prevTemperature = thermostat.Temperature;
            thermostat.SetTemperature(newTemperature);
        }

        public void UnExecute()
        {
            thermostat.SetTemperature(prevTemperature);
        }
    }
    // Планировщик команд – дает возможность отложенного и упорядоченного выполнения команд
    public class MacroCommand : ICommand
    {
        private List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void Execute()
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }

        public void UnExecute()
        {
            for (int i = commands.Count - 1; i >= 0; i--)
            {
                commands[i].UnExecute();
            }
        }
    }

    public class CommandScheduler
    {
        private List<ICommand> commands = new List<ICommand>();
        private Stack<ICommand> history = new Stack<ICommand>();

        public void ScheduleCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
                history.Push(command);
            }

            commands.Clear();
        }

        public void UndoLastCommand()
        {
            if (history.Count > 0)
            {
                ICommand lastCommand = history.Pop();
                lastCommand.UnExecute();
            }
            else
            {
                Console.WriteLine("no commands");
            }
        }
    }
}