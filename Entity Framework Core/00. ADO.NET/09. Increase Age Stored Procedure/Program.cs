using System;
using System.Data.SqlClient;
using System.Text;

namespace _09._Increase_Age_Stored_Procedure
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
                int minionId = Convert.ToInt32(Console.ReadLine());
                string result = IncreaseAge(sqlConnection, minionId);
                Console.WriteLine(result);
            }
        }
        private static string IncreaseAge(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder output = new StringBuilder();
            SqlCommand sqlCommand01 = new SqlCommand(@"EXEC [dbo].[usp_GetOlder] @minionId", sqlConnection);
            sqlCommand01.Parameters.AddWithValue("@minionId", minionId);
            sqlCommand01.ExecuteNonQuery();

            SqlCommand sqlCommand02 = new SqlCommand(@"SELECT [Name], [Age] FROM [Minions] WHERE [Id] = @Id", sqlConnection);
            sqlCommand02.Parameters.AddWithValue("@Id", minionId);
            using (SqlDataReader reader = sqlCommand02.ExecuteReader())
            {
                while (reader.Read())
                {
                    output.AppendLine($"{reader["Name"]} – {reader["Age"]} years old");
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
