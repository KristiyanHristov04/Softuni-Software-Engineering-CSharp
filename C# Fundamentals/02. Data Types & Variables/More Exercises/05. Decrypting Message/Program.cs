using System;

namespace Decrypting_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            int id = 0;
            string cryptedMessage = "";

            for (int i = 0; i < n; i++)
            {
                char letter = Convert.ToChar(Console.ReadLine());
                id = letter + key;
                cryptedMessage += (char)id;
            }
            Console.WriteLine(cryptedMessage);
        }
    }
}
