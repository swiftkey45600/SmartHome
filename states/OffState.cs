namespace SmartHomeMVP
{
    public class OffState : ILightState
    {
        public string GetStatus(Light light) => $"Light in {light.Room} is OFF";
    }
}
