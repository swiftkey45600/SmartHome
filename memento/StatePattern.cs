namespace SmartHomeMVP
{ 
    public interface ILightState
    {
        string GetStatus(Light light);
    }
    public class OnState : ILightState
    {
        public string GetStatus(Light light)
        {
            return $"Light in {light.Room} is ON";
        }
    }
    public class OffState : ILightState
    {
        public string GetStatus(Light light)
        {
            return $"Light in {light.Room} is OFF";
        }
    }

    public class DimmedState : ILightState
    {
        public int Brightness { get; private set; }

        public DimmedState(int brightness)
        {
            Brightness = brightness;
        }

        public string GetStatus(Light light)
        {
            return $"Light in {light.Room} is dimmed to {Brightness}%)";
        }
    }

}