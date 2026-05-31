namespace SmartHomeMVP
{
    public class SmartHomeController
    {
        private static SmartHomeController? _instance;
        private readonly List<object> _devices = new List<object>();

        private SmartHomeController() { }

        public static SmartHomeController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SmartHomeController();
                return _instance;
            }
        }

        public void RegisterDevice(object device) => _devices.Add(device);

        private T? Find<T>() where T : class
        {
            foreach (var d in _devices)
                if (d is T t) return t;
            return null;
        }

        public void TurnLightOn()
        {
            var light = Find<Light>();
            if (light != null) light.TurnOn();
            else Console.WriteLine("No light registered.");
        }

        public void TurnLightOff()
        {
            var light = Find<Light>();
            if (light != null) light.TurnOff();
            else Console.WriteLine("No light registered.");
        }

        public string GetLightStatus()
        {
            var light = Find<Light>();
            return light != null ? light.GetStatus() : "No light registered";
        }

        public void SetThermostatTemperature(int temp)
        {
            var thermostat = Find<Thermostat>();
            if (thermostat != null) thermostat.SetTemperature(temp);
            else Console.WriteLine("No thermostat registered.");
        }

        public string GetThermostatStatus()
        {
            var thermostat = Find<Thermostat>();
            return thermostat != null ? thermostat.GetStatus() : "No thermostat registered";
        }

        public string GetSensorStatus()
        {
            var sensor = Find<Sensor>();
            return sensor != null ? sensor.GetStatus() : "No sensor registered";
        }

        public void TriggerSensor()
        {
            var sensor = Find<Sensor>();
            if (sensor != null) sensor.Trigger();
            else Console.WriteLine("No sensor registered.");
        }

        public void ResetSensor()
        {
            var sensor = Find<Sensor>();
            if (sensor != null) sensor.Reset();
            else Console.WriteLine("No sensor registered.");
        }
    }
}
