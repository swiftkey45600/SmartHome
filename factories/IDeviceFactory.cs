namespace SmartHomeMVP
{
    public interface IDeviceFactory
    {
        Light CreateLight(string room);
        Thermostat CreateThermostat(string room);
        Sensor CreateSensor(string room);
    }
}
