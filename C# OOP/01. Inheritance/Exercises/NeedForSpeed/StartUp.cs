namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Motorcycle motor = new Motorcycle(200, 100);
            RaceMotorcycle raceMotor = new RaceMotorcycle(200, 100);
            CrossMotorcycle crossMotor = new CrossMotorcycle(200, 100);

            motor.Drive(10);
            raceMotor.Drive(10);
            crossMotor.Drive(10);

            System.Console.WriteLine(motor.Fuel);
            System.Console.WriteLine(raceMotor.Fuel);
            System.Console.WriteLine(crossMotor.Fuel);

        }
    }
}
