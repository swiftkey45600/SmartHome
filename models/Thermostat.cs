namespace SmartHomeMVP
{
    public class Thermostat
    {
        public string Room { get; private set; }
        public int Temperature { get; private set; }

        public Thermostat(string room)
        {
            Room = room;
            Temperature = 20;
        }

        public void SetTemperature(int temp)
        {
            Temperature = temp;
            Console.WriteLine($"Thermostat in {Room} set to {Temperature}°C.");
        }

        public string GetStatus() => $"{Temperature}°C";

        public ThermostatMemento CreateMemento() => new ThermostatMemento(Temperature);

        public void Restore(ThermostatMemento memento)
        {
            Temperature = memento.GetTemperature();
        }
    }
}
