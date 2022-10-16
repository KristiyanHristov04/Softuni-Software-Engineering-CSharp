namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("Mechka");
            Snake snake = new Snake("Kobra");
            System.Console.WriteLine(bear.Name);
            System.Console.WriteLine(snake.Name);
        }
    }
}