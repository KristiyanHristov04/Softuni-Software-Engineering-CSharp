using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string word = "";
            for (int i = 1; i <= n; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                switch (number)
                {
                    case 1:

                        break;
                    case 2:
                        word += "a";
                        break;
                    case 22:
                        word += "b";
                        break;
                    case 222:
                        word += "c";
                        break;
                    case 3:
                        word += "d";
                        break;
                    case 33:
                        word += "e";
                        break;
                    case 333:
                        word += "f";
                        break;
                    case 4:
                        word += "g";
                        break;
                    case 44:
                        word += "h";
                        break;
                    case 444:
                        word += "i";
                        break;
                    case 5:
                        word += "j";
                        break;
                    case 55:
                        word += "k";
                        break;
                    case 555:
                        word += "l";
                        break;
                    case 6:
                        word += "m";
                        break;
                    case 66:
                        word += "n";
                        break;
                    case 666:
                        word += "o";
                        break;
                    case 7:
                        word += "p";
                        break;
                    case 77:
                        word += "q";
                        break;
                    case 777:
                        word += "r";
                        break;
                    case 7777:
                        word += "s";
                        break;
                    case 8:
                        word += "t";
                        break;
                    case 88:
                        word += "u";
                        break;
                    case 888:
                        word += "v";
                        break;
                    case 9:
                        word += "w";
                        break;
                    case 99:
                        word += "x";
                        break;
                    case 999:
                        word += "y";
                        break;
                    case 9999:
                        word += "z";
                        break;
                    case 0:
                        word += " ";
                        break;
                }
            }
            Console.WriteLine(word);

        }
    }
}
