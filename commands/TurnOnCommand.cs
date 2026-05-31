namespace SmartHomeMVP
{
    public class TurnOnCommand : ICommand
    {
        private readonly Light _light;

        public TurnOnCommand(Light light) => _light = light;

        public void Execute() => _light.TurnOn();
        public void UnExecute() => _light.TurnOff();
    }
}
