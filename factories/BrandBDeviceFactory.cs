namespace SmartHomeMVP
{
    public class BrandBLight : Light
    {
        public BrandBLight(string room) : base(room)
        {
            SetState(new DimmedState(50));
        }

        public new void TurnOn()
        {
            SetState(new OnState());
            Console.WriteLine($"[BrandB] Smart light in {Room} activated.");
        }

        public new void TurnOff()
        {
            SetState(new OffState());
            Console.WriteLine($"[BrandB] Smart light in {Room} deactivated.");
        }
    }

    public class BrandBSensor : Sensor
    {
        public BrandBSensor(string room) : base(room) { }

        public new void Trigger()
        {
            base.Trigger();
            Console.WriteLine($"[BrandB] Enhanced motion detected at {Room}!");
        }
    }

    public class BrandBDeviceFactory : IDeviceFactory
    {
        public Light CreateLight(string room) => new BrandBLight(room);
        public Thermostat CreateThermostat(string room)
        {
            var t = new Thermostat(room);
            t.SetTemperature(18);
            return t;
        }
        public Sensor CreateSensor(string room) => new BrandBSensor(room);
    }
}
