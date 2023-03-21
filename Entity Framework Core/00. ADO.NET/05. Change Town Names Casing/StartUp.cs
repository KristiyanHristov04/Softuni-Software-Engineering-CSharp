using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ChangeTownNamesCasing
{
    internal class StartUp
    {
        private static SqlConnection dbCon;

        static void Main()
        {
            Reader reader = new Reader();
            string connectionString = reader.ReadConnectionString();
            string input = reader.ReadUserInput();

            using (dbCon = new SqlConnection(connectionString))
            {
                dbCon.Open();
                string result = ChangeTownCasing(input);
                System.Console.WriteLine(result);
                dbCon.Close();
            }
        }

        static string ChangeTownCasing(string countryName)
        {
            string findCountryIdQuery = $"SELECT Id FROM Countries WHERE Name = '{countryName}'";
            SqlCommand cmd = new SqlCommand(findCountryIdQuery, dbCon);
            int countryId = (int)cmd.ExecuteScalar();

            string findTownIdsQuery = $"SELECT Id FROM Towns WHERE CountryCode = {countryId}";
            cmd = new SqlCommand(findTownIdsQuery, dbCon);
            SqlDataReader sqlReader = cmd.ExecuteReader();

            HashSet<int> townIds = new HashSet<int>();
            while (sqlReader.Read())
            {
                townIds.Add((int)sqlReader["Id"]);
            }
            sqlReader.Close();

            HashSet<string> affectedTowns = new HashSet<string>();
            foreach (int id in townIds)
            {
                string townNameQuery = $"SELECT Name FROM Towns WHERE Id = {id}";
                SqlCommand cmdGetTownName = new SqlCommand(townNameQuery, dbCon);
                string townName = (string)cmdGetTownName.ExecuteScalar();
                string townNameUppercase = townName.ToUpper();

                string updateTownNameQuery = $"UPDATE Towns SET Name = '{townNameUppercase}' WHERE Id = {id}";
                SqlCommand cmdUpdateTownName = new SqlCommand(updateTownNameQuery, dbCon);

                int rowsAffected = cmdUpdateTownName.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    affectedTowns.Add(townNameUppercase);
                }
            }

            if (!affectedTowns.Any())
            {
                return "No town names were affected.";
            }
            else
            {
                string affectedTownNames = string.Join(", ", affectedTowns);
                return $"{affectedTowns.Count} town names were affected." + Environment.NewLine + $"[{affectedTownNames}]";
            }
        }
    }
}
