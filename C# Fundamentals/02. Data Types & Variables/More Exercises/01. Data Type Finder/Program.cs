using System;

namespace Data_Types_and_Variables___More_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solution: 1
            //string input = Console.ReadLine();
            //string dataType = "";
            //bool isString = true;
            //while (input != "End")
            //{
            //    try
            //    {
            //        int number = int.Parse(input);
            //        dataType = "integer";
            //        isString = false;
            //    }
            //    catch (Exception)
            //    {
            //        try
            //        {
            //            double number = double.Parse(input);
            //            dataType = "floating point";
            //            isString = false;
            //        }
            //        catch (Exception)
            //        {
            //            try
            //            {
            //                char number = char.Parse(input);
            //                dataType = "character";
            //                isString = false;
            //            }
            //            catch (Exception)
            //            {
            //                try
            //                {
            //                    bool number = bool.Parse(input);
            //                    dataType = "boolean";
            //                    isString = false;
            //                }
            //                catch (Exception)
            //                {
            //                    if (isString)
            //                    {
            //                        dataType = "string";
            //                    }
            //                }
            //            }
            //        }
            //    }              
            //    Console.WriteLine($"{input} is {dataType} type");
            //    input = Console.ReadLine();
            //    isString = true;
            //}

            //Solution: 2
            string input = Console.ReadLine();
            int valueInt;
            float valueFloat;
            char valueChar;
            bool valueBoolean;

            while (input != "END")
            {
                if (int.TryParse(input, out valueInt))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out valueFloat))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out valueChar))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out valueBoolean))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }
        }
    }
}
