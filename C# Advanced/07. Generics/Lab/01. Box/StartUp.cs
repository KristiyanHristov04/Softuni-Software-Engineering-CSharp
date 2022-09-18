using System;

namespace BoxOfT
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            box.Add("Pesho");
            box.Add("Toni");
            box.Add("Blagoi");
            Console.WriteLine(box.Remove());
            box.Add("Ivan");
            box.Add("Angel");
            Console.WriteLine(box.Remove());
        }
    }
}
