namespace SmartHomeMVP
{
    public class AutomationRoutineBuilder
    {
        private string _description = "";

        public AutomationRoutineBuilder AddTurnOnCommand(string device)
        {
            _description += $"Turn on {device}; ";
            return this;
        }

        public AutomationRoutineBuilder AddTurnOffCommand(string device)
        {
            _description += $"Turn off {device}; ";
            return this;
        }

        public AutomationRoutineBuilder AddSetTemperatureCommand(string device, int temperature)
        {
            _description += $"Set {device} to {temperature}°C; ";
            return this;
        }

        public AutomationRoutineBuilder AddLockCommand(string door)
        {
            _description += $"Lock {door}; ";
            return this;
        }

        public AutomationRoutineBuilder AddUnlockDoorCommand(string door)
        {
            _description += $"Unlock {door}; ";
            return this;
        }

        public AutomationRoutineBuilder AddWaitCommand(int seconds)
        {
            _description += $"Wait {seconds}s; ";
            return this;
        }

        public AutomationRoutine Build() => new AutomationRoutine(_description);
    }
}
