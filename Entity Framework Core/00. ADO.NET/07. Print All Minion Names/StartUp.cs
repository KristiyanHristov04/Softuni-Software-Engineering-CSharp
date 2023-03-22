using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PrintAllMinionNames
{
    internal class StartUp
    {
        private static SqlConnection dbCon;

        static void Main()
        {
            Reader reader = new Reader();
            string connectionString = reader.ReadConnectionString();

            IEnumerable<string> minionNames;
            using (dbCon = new SqlConnection(connectionString))
            {
                dbCon.Open();                               
                minionNames = GetAllMinionNames();                
                dbCon.Close();
            }

            minionNames = RearrangeMinionNames(minionNames.ToList());
            Console.WriteLine(String.Join(Environment.NewLine, minionNames));
        }

        static IEnumerable<string> GetAllMinionNames()
        {
            Queue<string> names = new Queue<string>();
            string minionNamesQuery = @"SELECT Name FROM Minions";
            SqlCommand cmd = new SqlCommand(minionNamesQuery, dbCon);
            using SqlDataReader sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                names.Enqueue(sqlReader.GetString(0));
            }
            sqlReader.Close();
            return names as IEnumerable<string>;
        }


        static IEnumerable<string> RearrangeMinionNames(List<string> minionNames)
        {
            Queue<string> orderedNames = new Queue<string>();
            bool takeFirstElement = true;
            while (minionNames.Any())
            {
                if (takeFirstElement)
                {
                    orderedNames.Enqueue(minionNames.First());
                    minionNames.RemoveAt(0);
                }
                else
                {
                    orderedNames.Enqueue(minionNames.Last());
                    minionNames.RemoveAt(minionNames.Count - 1);
                }
                takeFirstElement = !takeFirstElement;
            }
            return orderedNames;
        }
    }
}
