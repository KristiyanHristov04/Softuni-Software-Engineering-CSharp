using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._Minion_Names
{
    internal class Config
    {
        public string path = @"..\..\..\connectionString.txt";

        public string ReturnConnectionString()
        {
            string connectionString = null;
            using (StreamReader reader = new StreamReader(path))
            {
                connectionString = reader.ReadToEnd();
            }

            return connectionString;
        }
    }
}
