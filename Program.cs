

namespace SmartHomeMVP
{
    class Program
    {
        static void Main(string[] args)
        {
            Light light = new Light("Kitchen");
            light.TurnOn();
            // Сохраняем текущее состояние
            LightMemento memento = light.CreateMemento();
            Console.WriteLine("Status after TurnOn: " + light.GetStatus());

            light.TurnOff();
            Console.WriteLine("Status after TurnOff: " + light.GetStatus());

            // Восстанавливаем состояние из мементо
            light.Restore(memento);
            Console.WriteLine("Status after Restore: " + light.GetStatus());

            Console.ReadLine();
        }
    }    
}
