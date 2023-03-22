using System;
using System.IO;
using System.Linq;

namespace IncreaseMinionAge
{
    internal class Reader
    {
        private const string CONFIG_FILE_PATH = @"..\..\..\Config.txt";

        public string ReadConnectionString()
        {
            using StreamReader configReader = new StreamReader(CONFIG_FILE_PATH);
            return configReader.ReadLine();
        }

        public int[] ReadInputNumbers()
        => Console.ReadLine().Split().Select(int.Parse).ToArray();        
    }
}