namespace SmartHomeMVP
{
    public class StateManager
    {
        private LightMemento? _lightMemento;
        private ThermostatMemento? _thermostatMemento;

        public void SaveState(Light light, Thermostat thermostat)
        {
            _lightMemento = light.CreateMemento();
            _thermostatMemento = thermostat.CreateMemento();
            Console.WriteLine("State saved.");
        }

        public void RestoreState(Light light, Thermostat thermostat)
        {
            if (_lightMemento != null && _thermostatMemento != null)
            {
                light.Restore(_lightMemento);
                thermostat.Restore(_thermostatMemento);
                Console.WriteLine("State restored.");
            }
            else
            {
                Console.WriteLine("No saved state to restore.");
            }
        }
    }
}
