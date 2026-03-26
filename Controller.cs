

namespace SmartHomeMVP
{
    public class SmartHomeController
    {
        private static SmartHomeController instance;
        private List<object> devices;

        private SmartHomeController()
        {
            devices = new List<object>();
        }

        public static SmartHomeController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SmartHomeController();
                }

                return instance;
            }
        }

        public void RegisterDevice(object device)
        {
            devices.Add(device);
        }

        private Light FindFirstLight()
        {
            foreach (object device in devices)
            {
                if (device is Light light)
                {
                    return light;
                }
            }

            return null;
        }

        private Thermostat FindFirstThermostat()
        {
            foreach (object device in devices)
            {
                if (device is Thermostat thermostat)
                {
                    return thermostat;
                }
            }

            return null;
        }

        private Sensor FindFirstSensor()
        {
            foreach (object device in devices)
            {
                if (device is Sensor sensor)
                {
                    return sensor;
                }
            }

            return null;
        }

        public void TurnLightOn()
        {
            Light light = FindFirstLight();
            if (light != null)
            {
                light.TurnOn();
            }
            else
            {
                Console.WriteLine("No light registered.");
            }
        }

        public void TurnLightOff()
        {
            Light light = FindFirstLight();
            if (light != null)
            {
                light.TurnOff();
            }
            else
            {
                Console.WriteLine("No light registered.");
            }
        }

        public string GetLightStatus()
        {
            Light light = FindFirstLight();
            return light != null ? light.GetStatus() : "No light registered";
        }

        public void SetThermostatTemperature(int temp)
        {
            Thermostat thermostat = FindFirstThermostat();
            if (thermostat != null)
            {
                thermostat.SetTemperature(temp);
            }
            else
            {
                Console.WriteLine("No thermostat registered.");
            }
        }

        public string GetThermostatStatus()
        {
            Thermostat thermostat = FindFirstThermostat();
            return thermostat != null ? thermostat.GetStatus() : "No thermostat registered";
        }

        public string GetSensorStatus()
        {
            Sensor sensor = FindFirstSensor();
            return sensor != null ? sensor.GetStatus() : "No sensor registered";
        }

        public void TriggerSensor()
        {
            Sensor sensor = FindFirstSensor();
            if (sensor != null)
            {
                sensor.Trigger();
            }
            else
            {
                Console.WriteLine("No sensor registered.");
            }
        }

        public void ResetSensor()
        {
            Sensor sensor = FindFirstSensor();
            if (sensor != null)
            {
                sensor.Reset();
            }
            else
            {
                Console.WriteLine("No sensor registered.");
            }
        }
    }
}