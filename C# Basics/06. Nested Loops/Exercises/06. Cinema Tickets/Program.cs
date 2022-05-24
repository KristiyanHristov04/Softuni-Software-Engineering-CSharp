using System;

namespace Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            //06. Cinema Tickets
            string movieName = Console.ReadLine(); //Име на филма
            int availableSpace = Convert.ToInt32(Console.ReadLine()); // Свободни места
            int totalBoughtTickets = 0; //Общо закупени билети от всички прожекции
            bool isFinished = false; //Проверяваме дали сме въвели ключовата дума "isFinished"
            double soldStudentTickets = 0; //Общо продадени студенстки билети
            double soldStandardTickets = 0; //Общо продадени стандартски билети
            double soldKidTickets = 0; //Общо продадени детски билети
            int boughtTicketsForCurrentMovie = 0;

            while (movieName != "Finish")
            {
                string typeOfTicket = Console.ReadLine(); //Вид на билета
                while (typeOfTicket != "End")
                {                   
                    if (typeOfTicket == "student")
                    {
                        soldStudentTickets++;
                        availableSpace--;
                        totalBoughtTickets++;
                        boughtTicketsForCurrentMovie++;
                    }
                    else if (typeOfTicket == "standard")
                    {
                        soldStandardTickets++;
                        availableSpace--;
                        totalBoughtTickets++;
                        boughtTicketsForCurrentMovie++;
                    }
                    else if (typeOfTicket == "kid")
                    {
                        soldKidTickets++;
                        availableSpace--;
                        totalBoughtTickets++;
                        boughtTicketsForCurrentMovie++;
                    }
                    typeOfTicket = Console.ReadLine();
                    if (typeOfTicket == "Finish")
                    {
                        
                        isFinished = true;
                        break;
                    }
                }
                if (isFinished == true)
                {                   
                    break;
                }
                else if(typeOfTicket == "End")
                {
                    Console.WriteLine($"{movieName} - {totalBoughtTickets * 10:f2}% full.");
                    boughtTicketsForCurrentMovie = 0;
                    movieName = Console.ReadLine();
                }
                else
                {
                    movieName = Console.ReadLine();                   
                }               
            }
            if (isFinished == true)
            {
                Console.WriteLine($"{movieName} - {totalBoughtTickets * 10:f2}% full.");
            }
            Console.WriteLine($"Total tickets: {totalBoughtTickets}");
            Console.WriteLine($"{soldStudentTickets / totalBoughtTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{soldStandardTickets / totalBoughtTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{soldKidTickets / totalBoughtTickets * 100:f2}% kids tickets.");       
        }
    }
}
