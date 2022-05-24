using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            double razreditelZaBoqZaLitur = 5.00;
            double SumaZaTorbichki = 0.40;


            int neobhodimoKolichestvoNailon = Convert.ToInt32(Console.ReadLine());
            int neobhodimoKolichestvoBoq = Convert.ToInt32(Console.ReadLine());
            int neobhodimoKolichestvoRazreditelZaBoq = Convert.ToInt32(Console.ReadLine());
            int NujniChasoveNaMaistoriteDaSvurshatRobotata = Convert.ToInt32(Console.ReadLine());





            double discount = neobhodimoKolichestvoBoq * 14.50 + (10 * (neobhodimoKolichestvoBoq * 14.50 / 100));
            double discount2 = discount - neobhodimoKolichestvoBoq * 14.50;

            double obshtaSumaZaVsichkiMateriali = (neobhodimoKolichestvoNailon + 2) * 1.50 +
                neobhodimoKolichestvoBoq * 14.50 + discount2 +// + 10 trqbva da e procent -> + 10% (1.1)
                neobhodimoKolichestvoRazreditelZaBoq * razreditelZaBoqZaLitur +
                SumaZaTorbichki;

            double sumaZaMaistori = (obshtaSumaZaVsichkiMateriali * 0.30) * NujniChasoveNaMaistoriteDaSvurshatRobotata; // * 30 trqbva da e procent -> 30% (0.30)



            double krainaSuma = obshtaSumaZaVsichkiMateriali + sumaZaMaistori;

            Console.WriteLine($"{krainaSuma}");
        }
    }
}
