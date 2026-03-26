

namespace SmartHomeMVP
{
    public class AutomationRoutine
    {
	    public string Description { get; private set; }
	
	    public AutomationRoutine(string description)
	    {
		    Description = description;
	    }
	    public void Execute()
	    {
		    Console.WriteLine("Executing Automation Routine:");
		    Console.WriteLine(Description);
	    }
        public AutomationRoutine Clone()
        {
            return new AutomationRoutine(Description);
        }
    }
    public class AutomationRoutineBuilder
    {
        private string description = "";

        public AutomationRoutineBuilder AddTurnOnCommand(string device)
        {
            description += $"Turn on {device}; ";
            return this;
        }

        public AutomationRoutineBuilder AddTurnOffCommand(string device)
        {
            description += $"Turn off {device}; ";
            return this;
        }

        public AutomationRoutineBuilder AddSetTemperatureCommand(string device, int temperature)
        {
            description += $"Set {device} to {temperature}°C; ";
            return this;
        }

        public AutomationRoutine Build()
        {
            return new AutomationRoutine(description);
        }
    }
}