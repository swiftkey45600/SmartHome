

namespace SmartHomeMVP
{
    public class Light
    {
        // Название комнаты, где расположено устройство
        public string Room { get; private set; }
        // Текущее состояние: true = включено, false = выключено
        public bool IsOn { get; private set; }

        // Конструктор, устанавливающий название комнаты и начальное состояние (выключено)
        public Light(string room)
        {
            Room = room;
            IsOn = false;
        }

        // Метод для включения света
        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"The light in {Room} is turned on.");
        }

        // Метод для выключения света
        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"The light in {Room} is turned off.");
        }

        // Метод для получения текущего состояния устройства в виде строки
        public string GetStatus()
        {
            return IsOn ? "On" : "Off";
        }

        public LightMemento CreateMemento()
        {
            return new LightMemento(IsOn);
        }

        public void Restore(LightMemento memento)
        {
            IsOn = memento.GetIsOn();
        }
    }
}