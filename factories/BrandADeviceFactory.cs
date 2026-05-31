namespace SmartHomeMVP
{
    public class BrandADeviceFactory : IDeviceFactory
    {
        public Light CreateLight(string room) => new Light(room);
        public Thermostat CreateThermostat(string room) => new Thermostat(room);
        public Sensor CreateSensor(string room) => new Sensor(room);
    }
}
