using System;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string leftInput = input[0];
            string rightInput = input[1];
            int result = 0;
            if (leftInput.Length == rightInput.Length)
            {
                for (int i = 0; i < leftInput.Length; i++)
                {
                    result += Convert.ToInt32(leftInput[i]) * Convert.ToInt32(rightInput[i]);
                }
                Console.WriteLine(result);
                return;
            }
            else if(leftInput.Length < rightInput.Length)
            {
                int reminder = rightInput.Length - leftInput.Length;
                for (int i = 0; i < leftInput.Length; i++)
                {
                    result += Convert.ToInt32(leftInput[i]) * Convert.ToInt32(rightInput[i]);
                }

                for (int i = rightInput.Length - reminder; i < rightInput.Length; i++)
                {
                    result += Convert.ToInt32(rightInput[i]);
                }
                Console.WriteLine(result);
                return;
            }
            else if(leftInput.Length > rightInput.Length)
            {
                int reminder = leftInput.Length - rightInput.Length;
                for (int i = 0; i < rightInput.Length; i++)
                {
                    result += Convert.ToInt32(leftInput[i]) * Convert.ToInt32(rightInput[i]);
                }

                for (int i = leftInput.Length - reminder; i < leftInput.Length; i++)
                {
                    result += Convert.ToInt32(leftInput[i]);
                }
                Console.WriteLine(result);
                return;
            }
        }
    }
}
