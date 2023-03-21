using System;
using System.Data.SqlClient;
using System.Text;

namespace _03._Minion_Names
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
                string result = GetVillainsMinionsCount(sqlConnection);
                Console.WriteLine(result);
            }
        }
        private static string GetVillainsMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();
            SqlCommand sqlCommand = new SqlCommand(@"SELECT [v].[Name], COUNT(*) AS [MinionsCount] FROM [Villains] AS [v]
                                                       JOIN [MinionsVillains] AS [mv] ON [mv].VillainId = [v].Id
                                                       GROUP BY [v].[Name]
                                                       HAVING COUNT(*) > 3
                                                       ORDER BY [MinionsCount]", sqlConnection);

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string villainName = (string)reader["Name"];
                    int minionsUnderControl = (int)reader["MinionsCount"];
                    output.AppendLine($"{villainName} - {minionsUnderControl}");
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
