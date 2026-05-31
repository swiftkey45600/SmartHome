namespace SmartHomeMVP
{
    class Program
    {
        static void Main(string[] args)
        {
            // === Abstract Factory + Singleton ===
            Console.WriteLine("=== Abstract Factory + Singleton ===");
            IDeviceFactory factory = new BrandADeviceFactory();
            Light light = factory.CreateLight("Living Room");
            Thermostat thermostat = factory.CreateThermostat("Living Room");
            Sensor sensor = factory.CreateSensor("Hallway");

            SmartHomeController controller = SmartHomeController.Instance;
            controller.RegisterDevice(light);
            controller.RegisterDevice(thermostat);
            controller.RegisterDevice(sensor);

            Console.WriteLine("Light: " + controller.GetLightStatus());
            controller.TurnLightOn();
            Console.WriteLine("Light: " + controller.GetLightStatus());
            Console.WriteLine("Sensor: " + controller.GetSensorStatus());

            // Переключение на BrandB одной строкой:
            // IDeviceFactory factory = new BrandBDeviceFactory();

            // === Builder + Prototype ===
            Console.WriteLine("\n=== Builder + Prototype ===");
            AutomationRoutine routine = new AutomationRoutineBuilder()
                .AddTurnOnCommand("Living Room Light")
                .AddSetTemperatureCommand("Thermostat", 22)
                .AddLockCommand("Front Door")
                .AddWaitCommand(30)
                .Build();

            AutomationRoutine routineClone = routine.Clone();

            routine.Execute();
            Console.WriteLine("--- Clone ---");
            routineClone.Execute();

            // === Command + Scheduler ===
            Console.WriteLine("\n=== Command + Scheduler ===");
            Light garageLight = factory.CreateLight("Garage");
            CommandScheduler scheduler = new CommandScheduler();
            scheduler.ScheduleCommand(new TurnOnCommand(garageLight));
            scheduler.ScheduleCommand(new SetTemperatureCommand(thermostat, 24));
            scheduler.ExecuteCommands();

            Console.WriteLine("Undo last command:");
            scheduler.UndoLastCommand();

            Console.WriteLine("\nMacro command:");
            MacroCommand macro = new MacroCommand();
            macro.AddCommand(new TurnOnCommand(garageLight));
            macro.AddCommand(new SetTemperatureCommand(thermostat, 20));
            macro.Execute();
            Console.WriteLine("Undo macro:");
            macro.UnExecute();

            // === Memento ===
            Console.WriteLine("\n=== Memento ===");
            StateManager stateManager = new StateManager();
            light.TurnOn();
            thermostat.SetTemperature(22);
            stateManager.SaveState(light, thermostat);

            light.TurnOff();
            thermostat.SetTemperature(30);
            Console.WriteLine("After changes — Light: " + light.GetStatus() + ", Thermostat: " + thermostat.GetStatus());

            stateManager.RestoreState(light, thermostat);
            Console.WriteLine("After restore — Light: " + light.GetStatus() + ", Thermostat: " + thermostat.GetStatus());

            // === State ===
            Console.WriteLine("\n=== State ===");
            Light bedroomLight = factory.CreateLight("Bedroom");
            Console.WriteLine("Initial: " + bedroomLight.GetStatus());

            bedroomLight.SetState(new OnState());
            Console.WriteLine("After OnState: " + bedroomLight.GetStatus());

            bedroomLight.SetState(new DimmedState(40));
            Console.WriteLine("After DimmedState(40): " + bedroomLight.GetStatus());

            bedroomLight.SetState(new OffState());
            Console.WriteLine("After OffState: " + bedroomLight.GetStatus());

            Console.ReadLine();
        }
    }
}
