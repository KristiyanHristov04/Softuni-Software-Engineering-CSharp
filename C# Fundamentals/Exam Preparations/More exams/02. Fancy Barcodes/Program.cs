using System;
using System.Text.RegularExpressions;
namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfBarcodes = Convert.ToInt32(Console.ReadLine());
            string barcodePattern = @"\@[#]{1,}(?<barcode>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1})\@[#]{1,}";
            string productGroupPattern = @"(?<digits>[0-9])";
            for (int i = 0; i < numberOfBarcodes; i++)
            {
                string currentBarcode = Console.ReadLine();
                string digits = string.Empty;
                if (Regex.IsMatch(currentBarcode, barcodePattern))
                {
                    MatchCollection matches = Regex.Matches(currentBarcode, productGroupPattern);
                    foreach (Match match in matches)
                    {
                        digits += match.Groups["digits"].Value;
                    }
                    if (digits == string.Empty)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {digits}");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
