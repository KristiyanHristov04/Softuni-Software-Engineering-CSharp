using System;

namespace _04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string morseCode = Console.ReadLine() + " ";
            string finalText = string.Empty;

            string currentText = string.Empty;
            for (int i = 0; i < morseCode.Length; i++)
            {
                string currSymbol = morseCode[i].ToString();
                if (currSymbol == " ")
                {
                    if (currentText == ".-")
                    {
                        finalText += "A";
                    }
                    else if(currentText == "-...")
                    {
                        finalText += "B";
                    }
                    else if (currentText == "-.-.")
                    {
                        finalText += "C";
                    }
                    else if (currentText == "-..")
                    {
                        finalText += "D";
                    }
                    else if (currentText == ".")
                    {
                        finalText += "E";
                    }
                    else if (currentText == "..-.")
                    {
                        finalText += "F";
                    }
                    else if (currentText == "--.")
                    {
                        finalText += "G";
                    }
                    else if (currentText == "....")
                    {
                        finalText += "H";
                    }
                    else if (currentText == "..")
                    {
                        finalText += "I";
                    }
                    else if (currentText == ".---")
                    {
                        finalText += "J";
                    }
                    else if (currentText == "-.-")
                    {
                        finalText += "K";
                    }
                    else if (currentText == ".-..")
                    {
                        finalText += "L";
                    }
                    else if (currentText == "--")
                    {
                        finalText += "M";
                    }
                    else if (currentText == "-.")
                    {
                        finalText += "N";
                    }
                    else if (currentText == "---")
                    {
                        finalText += "O";
                    }
                    else if (currentText == ".--.")
                    {
                        finalText += "P";
                    }
                    else if (currentText == "--.-")
                    {
                        finalText += "Q";
                    }
                    else if (currentText == ".-.")
                    {
                        finalText += "R";
                    }
                    else if (currentText == "...")
                    {
                        finalText += "S";
                    }
                    else if (currentText == "-")
                    {
                        finalText += "T";
                    }
                    else if (currentText == "..-")
                    {
                        finalText += "U";
                    }
                    else if (currentText == "...-")
                    {
                        finalText += "V";
                    }
                    else if (currentText == ".--")
                    {
                        finalText += "W";
                    }
                    else if (currentText == "-..-")
                    {
                        finalText += "X";
                    }
                    else if (currentText == "-.--")
                    {
                        finalText += "Y";
                    }
                    else if (currentText == "--..")
                    {
                        finalText += "Z";
                    }
                    currentText = string.Empty;

                }
                else if(currSymbol == "|")
                {
                    finalText += " ";
                }  
                else
                {
                    currentText += currSymbol;
                }
            }
            Console.WriteLine(finalText);
            
        }
    }
}
