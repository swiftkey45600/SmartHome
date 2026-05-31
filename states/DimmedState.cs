namespace SmartHomeMVP
{
    public class DimmedState : ILightState
    {
        public int Brightness { get; private set; }

        public DimmedState(int brightness)
        {
            Brightness = brightness;
        }

        public string GetStatus(Light light) => $"Light in {light.Room} is dimmed to {Brightness}%";
    }
}
