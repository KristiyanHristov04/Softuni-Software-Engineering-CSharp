namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Normal Wizard", 15);
            DarkWizard darkWizard = new DarkWizard("Dark Wizard", 25);
            System.Console.WriteLine(wizard);
            System.Console.WriteLine(darkWizard);
        }
    }
}