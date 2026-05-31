namespace SmartHomeMVP
{
    public class Light
    {
        public string Room { get; private set; }
        private ILightState _state;

        public bool IsOn => _state is OnState;

        public Light(string room)
        {
            Room = room;
            _state = new OffState();
        }

        public void TurnOn()
        {
            _state = new OnState();
            Console.WriteLine($"The light in {Room} is turned on.");
        }

        public void TurnOff()
        {
            _state = new OffState();
            Console.WriteLine($"The light in {Room} is turned off.");
        }

        public void SetState(ILightState state)
        {
            _state = state;
        }

        public string GetStatus() => _state.GetStatus(this);

        public LightMemento CreateMemento() => new LightMemento(IsOn);

        public void Restore(LightMemento memento)
        {
            _state = memento.GetIsOn() ? (ILightState)new OnState() : new OffState();
        }
    }
}
