using System;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int threshold = Convert.ToInt32(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<int, bool> function = sum => sum >= threshold;
            Console.WriteLine(FindName(names, function));
        }
        public static string FindName(string[] names, Func<int, bool> functionParameter)
        {
            string returningValue = string.Empty;
            for (int i = 0; i < names.Length; i++)
            {
                int sum = 0;
                string currentName = names[i];
                char[] charredName = currentName.ToCharArray();
                for (int j = 0; j < charredName.Length; j++)
                {
                    sum += charredName[j];
                }
                if (functionParameter(sum))
                {
                    returningValue = currentName;
                    break;
                }
            }
            return returningValue;
        }
    }
}
