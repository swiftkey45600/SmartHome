namespace SmartHomeMVP
{
    public class OnState : ILightState
    {
        public string GetStatus(Light light) => $"Light in {light.Room} is ON";
    }
}
