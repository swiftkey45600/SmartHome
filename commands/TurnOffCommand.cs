namespace SmartHomeMVP
{
    public class TurnOffCommand : ICommand
    {
        private readonly Light _light;

        public TurnOffCommand(Light light) => _light = light;

        public void Execute() => _light.TurnOff();
        public void UnExecute() => _light.TurnOn();
    }
}
