

namespace SmartHomeMVP
{
    public class StateManager
    {
        private LightMemento lightMemento;
        private ThermostatMemento thermostatMemento;

        public void SaveState(Light light, Thermostat thermostat)
        {
            lightMemento = light.CreateMemento();
            thermostatMemento = thermostat.CreateMemento();
        }

        public void RestoreState(Light light, Thermostat thermostat)
        {
            if (lightMemento != null && thermostatMemento != null)
            {
                light.Restore(lightMemento);
                thermostat.Restore(thermostatMemento);
            }
            else
            {
                Console.WriteLine("no saved state to restore");
            }
        }
    }
}