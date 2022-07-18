using System;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cryptedMessage = Console.ReadLine();
            string encryptedMessage = string.Empty;
            for (int i = 0; i < cryptedMessage.Length; i++)
            {
                encryptedMessage += Convert.ToChar(cryptedMessage[i] + 3);
            }
            Console.WriteLine(encryptedMessage);
        }
    }
}
