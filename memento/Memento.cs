namespace SmartHomeMVP
{
    public class LightMemento
    {
        private bool savedIsOn;

        public LightMemento(bool IsOn)
        {
            savedIsOn = IsOn;
        }

        public bool GetIsOn()
        {
            return savedIsOn;
        }
    }
    public class ThermostatMemento
    {
        private int savedTemperature;

        public ThermostatMemento(int temperature)
        {
            savedTemperature = temperature;
        }

        public int GetTemperature()
        {
            return savedTemperature;
        }
    }
}