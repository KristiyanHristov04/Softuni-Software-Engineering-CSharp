using System;

namespace SoftuniExercices1
{
    class Program
    {
        static void Main(string[] args)
        {
            double depoziranaSuma = Convert.ToDouble(Console.ReadLine());
            int srokNaDepozita = Convert.ToInt32(Console.ReadLine());
            double godishenLihvenProcent = Convert.ToDouble(Console.ReadLine());
            double natrupanaLihva = depoziranaSuma * (godishenLihvenProcent / 100);
            double lihvaZaEdinMesec = natrupanaLihva / 12;
            double obshtaSuma = depoziranaSuma + srokNaDepozita * lihvaZaEdinMesec;
            Console.WriteLine(obshtaSuma);
        }
    }
}
