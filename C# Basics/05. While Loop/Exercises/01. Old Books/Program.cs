using System;

namespace SoftUniWhileLoopExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Old Books
            string specificBook = Console.ReadLine();
            string currentBook = Console.ReadLine();
            int numberOfCheckedBooks = 0;
            while (currentBook != specificBook)
            {
                if (currentBook == "No More Books")
                {
                    break;
                }
                numberOfCheckedBooks++;
                currentBook = Console.ReadLine();
            }
            if (currentBook == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {numberOfCheckedBooks} books.");
            }
            else
            {
                Console.WriteLine($"You checked {numberOfCheckedBooks} books and found it.");
            }
            
        }
    }
}
