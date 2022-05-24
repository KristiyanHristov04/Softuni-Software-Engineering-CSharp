using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiStranici = Convert.ToInt32(Console.ReadLine());
            int procheteniStraniciZa1Chas = Convert.ToInt32(Console.ReadLine());
            int broqtNaDniteZaKoitoTrqbvaDaSeProcheteKnigata = Convert.ToInt32(Console.ReadLine());
            int chasoveObshto = broiStranici / procheteniStraniciZa1Chas;
            int neobhodimiChasoveNaDenZaProchitanetoNaKnigata = chasoveObshto / broqtNaDniteZaKoitoTrqbvaDaSeProcheteKnigata;
            Console.WriteLine(neobhodimiChasoveNaDenZaProchitanetoNaKnigata);
        }
    }
}
