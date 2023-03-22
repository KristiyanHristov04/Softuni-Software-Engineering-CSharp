using System;
using System.IO;

namespace PrintAllMinionNames
{
    internal class Reader
    {
        private const string CONFIG_FILE_PATH = @"..\..\..\Config.txt";

        public string ReadConnectionString()
        {
            using StreamReader configReader = new StreamReader(CONFIG_FILE_PATH);
            return configReader.ReadLine();
        }

    }
}