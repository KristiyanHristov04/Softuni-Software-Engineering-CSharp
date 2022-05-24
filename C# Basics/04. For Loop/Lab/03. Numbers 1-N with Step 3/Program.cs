using System;

namespace Numbers_1_N_with_Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //03. Numbers 1...N with Step 3
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
