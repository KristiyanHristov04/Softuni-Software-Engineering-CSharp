using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IncreaseMinionAge
{
    internal class StartUp
    {
        private static SqlConnection dbCon;

        static void Main()
        {
            Reader reader = new Reader();
            string connectionString = reader.ReadConnectionString();
            int[] minionIds = reader.ReadInputNumbers();

            using (dbCon = new SqlConnection(connectionString))
            {
                dbCon.Open();
                IncrementMinionsAge(minionIds);
                CapitaliseMinionsNames(minionIds);
                string output = GetOutputString();
                Console.WriteLine(output);
                dbCon.Close();
            }
        }

        static void IncrementMinionsAge(int[] minionIds)
        {
            string query = @"UPDATE Minions SET Age += 1 WHERE Id = @Id";
            foreach (int id in minionIds)
            {
                SqlCommand cmd = new SqlCommand(query, dbCon);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        static void CapitaliseMinionsNames(int[] minionIds)
        {
            // Read Id-Name pairs and capitalise first letter
            var idsNames = new Dictionary<int, string>();
            string getNameQuery = @"SELECT Name FROM Minions WHERE Id = @Id";
            foreach (int id in minionIds)
            {
                SqlCommand cmd = new SqlCommand(getNameQuery, dbCon);
                cmd.Parameters.AddWithValue("@Id", id);

                string name = (string)cmd.ExecuteScalar();
                string[] splitName = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < splitName.Length; i++)
                {
                    char firstLetter = splitName[i].First();
                    splitName[i] = firstLetter.ToString().ToUpper() + splitName[i].Substring(1, splitName[i].Length - 1);
                }
                string newName = string.Join(" ", splitName);
                idsNames.Add(id, newName);
            }

            // Overwrite existing names with capitalised names
            string capitaliseFirstLetterQuery = @"UPDATE Minions SET Name = @NewName WHERE Id = @Id";
            foreach (var idName in idsNames)
            {
                SqlCommand cmd = new SqlCommand(capitaliseFirstLetterQuery, dbCon);
                cmd.Parameters.AddWithValue("@NewName", idName.Value);
                cmd.Parameters.AddWithValue("@Id", idName.Key);
                cmd.ExecuteNonQuery();
            }
        }

        static string GetOutputString()
        {
            string query = @"SELECT Name, Age FROM Minions";
            SqlCommand cmd = new SqlCommand(query, dbCon);

            StringBuilder sb = new StringBuilder();
            using SqlDataReader sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                string name = (string)sqlReader["Name"];
                int age = (int)sqlReader["Age"];
                sb.AppendLine($"{name} {age}");
            }
            sqlReader.Close();
            return sb.ToString().TrimEnd();
        }
    }
}