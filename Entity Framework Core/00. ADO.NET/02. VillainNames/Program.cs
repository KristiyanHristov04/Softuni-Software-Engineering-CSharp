using System;
using System.Data.SqlClient;
using System.Text;

namespace _02._VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config();
            string connectionString = config.ReturnConnectionString();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                int villainId = Convert.ToInt32(Console.ReadLine());
                string result = PrintMinionNames(sqlConnection, villainId);
                Console.WriteLine(result);
            }
        }
        private static string PrintMinionNames(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder output = new StringBuilder();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [Name] FROM [Villains]
                                                      WHERE [Id] = @villainId", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@villainId", villainId);
            string villainName = (string)sqlCommand.ExecuteScalar();

            if (villainName == null)
            {
                return $"No villain with ID <{villainId}> exists in the database.";
            }

            output.AppendLine($"Villain: {villainName}");

            SqlCommand sqlCommand2 = new SqlCommand(@"SELECT [m].[Name], [m].Age FROM [MinionsVillains] AS [mv]
                                                        JOIN [Minions] AS [m] ON [m].Id = [mv].MinionId
                                                        WHERE [mv].VillainId = @villainId", sqlConnection);

            sqlCommand2.Parameters.AddWithValue("villainId", villainId);
            bool areAny = false;
            int counter = 1;

            using (SqlDataReader reader = sqlCommand2.ExecuteReader())
            {
                while (reader.Read())
                {
                    areAny = true;
                    output.AppendLine($"{counter}. {reader["Name"]} {reader["Age"]}");
                    counter++;
                }
            }

            if (!areAny)
            {
                return "(no minions)";
            }

            return output.ToString().TrimEnd();
        }
    }
}
