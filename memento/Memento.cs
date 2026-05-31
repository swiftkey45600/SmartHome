namespace SmartHomeMVP
{
    public class LightMemento
    {
        private readonly bool _savedIsOn;

        public LightMemento(bool isOn) => _savedIsOn = isOn;

        public bool GetIsOn() => _savedIsOn;
    }

    public class ThermostatMemento
    {
        private readonly int _savedTemperature;

        public ThermostatMemento(int temperature) => _savedTemperature = temperature;

        public int GetTemperature() => _savedTemperature;
    }
}
