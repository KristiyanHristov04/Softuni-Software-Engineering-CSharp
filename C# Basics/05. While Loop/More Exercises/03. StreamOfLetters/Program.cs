using System;

namespace StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
          
            
            string input = Console.ReadLine();
            int meetO = 0;
            int meetC = 0;
            int meetN = 0;
            string word = "";
            string finalWord = "";
            while (input != "End")
            {
                
                char letter = input[0];
                bool isLetter = char.IsLetter(letter);
                if (isLetter == false)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (Convert.ToChar(input) == 'c')
                {
                    meetC++;
                    if (meetC == 1)
                    {
                        if (meetC >= 1 && meetN >= 1 && meetO >= 1)
                        {
                            finalWord = word + " ";
                            word += " ";
                            meetC = 0;
                            meetN = 0;
                            meetO = 0;
                            input = Console.ReadLine();
                            continue;
                        }
                        else if(meetC == 1)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        else
                        {

                        }
                        
                    }
                }
                else if (Convert.ToChar(input) == 'o')
                {
                    meetO++;                  
                    if (meetC >= 1 && meetN >= 1 && meetO >= 1)
                    {
                        finalWord = word + " ";
                        word += " ";
                        meetC = 0;
                        meetN = 0;
                        meetO = 0;
                        input = Console.ReadLine();
                        continue;
                    }
                    else if(meetO == 1)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {

                    }
                }
                else if (Convert.ToChar(input) == 'n')
                {
                    meetN++;
                    if (meetC >= 1 && meetN >= 1 && meetO >= 1)
                    {
                        finalWord = word + " ";
                        word += " ";
                        meetC = 0;
                        meetN = 0;
                        meetO = 0;
                        input = Console.ReadLine();
                        continue;
                    }
                    else if(meetN == 1)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {

                    }
                }
                
                word += input;
                input = Console.ReadLine();
                
                
            }
            Console.WriteLine(finalWord);
        }
    }
}

