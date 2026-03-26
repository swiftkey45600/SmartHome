
namespace SmartHomeMVP
{
    public class Sensor
    {
        public string Room { get; private set; }
        public bool IsTriggered { get; private set; }

        public Sensor(string room)
        {
            Room = room;
            IsTriggered = false;
        }

        public void Trigger()
        {
            IsTriggered = true;
            Console.WriteLine($"Sensor in {Room} was triggered.");
        }

        public void Reset()
        {
            IsTriggered = false;
            Console.WriteLine($"Sensor in {Room} was reset.");
        }

        public string GetStatus()
        {
            return IsTriggered ? "Triggered" : "Not Triggered";
        }
    }
}