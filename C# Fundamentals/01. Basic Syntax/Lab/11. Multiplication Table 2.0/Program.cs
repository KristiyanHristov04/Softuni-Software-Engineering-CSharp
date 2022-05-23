using System;

namespace _11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //11. Multiplication Table 2.0
            int n = Convert.ToInt32(Console.ReadLine());
            int fromWhere = Convert.ToInt32(Console.ReadLine());
            bool isValid = false;
            for (int i = fromWhere; fromWhere <= 10; fromWhere++)
            {
                Console.WriteLine($"{n} X {fromWhere} = {n * fromWhere}");
                isValid = true;
            }

            if (fromWhere > 10 && isValid == false)
            {
                Console.WriteLine($"{n} X {fromWhere} = {n * fromWhere}");
            }
        }
    }
}
