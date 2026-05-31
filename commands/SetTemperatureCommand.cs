namespace SmartHomeMVP
{
    public class SetTemperatureCommand : ICommand
    {
        private readonly Thermostat _thermostat;
        private readonly int _newTemperature;
        private int _prevTemperature;

        public SetTemperatureCommand(Thermostat thermostat, int newTemperature)
        {
            _thermostat = thermostat;
            _newTemperature = newTemperature;
        }

        public void Execute()
        {
            _prevTemperature = _thermostat.Temperature;
            _thermostat.SetTemperature(_newTemperature);
        }

        public void UnExecute() => _thermostat.SetTemperature(_prevTemperature);
    }
}
