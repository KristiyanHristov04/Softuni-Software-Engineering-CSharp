using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace _04._Add_Minion
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
                string[] minionInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string minionName = minionInformation[1];
                int minionAge = Convert.ToInt32(minionInformation[2]);
                string minionTown = minionInformation[3];

                string[] villainInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string villainName = villainInformation[1];

                string result = AddMinion(sqlConnection, minionTown, villainName, minionName, minionAge, minionTown);
                Console.WriteLine(result);
            }
        }
        private static string AddMinion(SqlConnection sqlConnection, string minionTown, string villainName, string minionName, int minionAge, string townName)
        {
            StringBuilder output = new StringBuilder();
            SqlCommand sqlCommand01 = new SqlCommand(@"SELECT [Name] FROM [Towns]
                                                        WHERE [Name] = @townName", sqlConnection);
            sqlCommand01.Parameters.AddWithValue("@townName", minionTown);
            string town = (string)sqlCommand01.ExecuteScalar();

            if (town != minionTown)
            {
                SqlCommand sqlCommand02 = new SqlCommand(@"INSERT INTO [Towns]([Name])		
                                                            	VALUES
                                                            		(@townName)", sqlConnection);
                sqlCommand02.Parameters.AddWithValue("@townName", minionTown);
                sqlCommand02.ExecuteNonQuery();
                output.AppendLine($"Town {minionTown} was added to the database.");
            }

            SqlCommand sqlCommand03 = new SqlCommand(@"SELECT [Name] FROM [Villains]
                                                        WHERE [Name] = @villainName", sqlConnection);
            sqlCommand03.Parameters.AddWithValue("@villainName", villainName);
            string villName = (string)sqlCommand03.ExecuteScalar();

            if (villName != villainName)
            {
                SqlCommand sqlCommand04 = new SqlCommand(@"INSERT INTO [Villains]([Name], [EvilnessFactorId])
	                                                       VALUES 
	                                                       	(@villainName, @evilNessFactorId)", sqlConnection);
                sqlCommand04.Parameters.AddWithValue("@villainName", villainName);
                sqlCommand04.Parameters.AddWithValue("@evilNessFactorId", 4);
                sqlCommand04.ExecuteNonQuery();
                output.AppendLine($"Villain {villainName} was added to the database.");
            }

            SqlCommand sqlCommand05 = new SqlCommand(@"SELECT [Name] FROM [Minions]
                                                        WHERE [Name] = @minionName", sqlConnection);
            sqlCommand05.Parameters.AddWithValue("@minionName", minionName);
            string minName = (string)sqlCommand05.ExecuteScalar();

            if (minName != minionName)
            {
                SqlCommand sqlCommand06 = new SqlCommand(@"INSERT INTO [Minions]([Name], [Age], [TownId])
                                                            	VALUES
		                                                                (@minionName, @minionAge, (
		                                              					                    SELECT [Id] FROM [Towns]
		                                      					                            WHERE [Name] = @townName
                                                                                        )
			                                              			     )", sqlConnection);


                sqlCommand06.Parameters.AddWithValue("@minionName", minionName);
                sqlCommand06.Parameters.AddWithValue("@minionAge", minionAge);
                sqlCommand06.Parameters.AddWithValue("@townName", townName);
                sqlCommand06.ExecuteNonQuery();
            }

            SqlCommand sqlCommand07 = new SqlCommand(@"INSERT INTO [MinionsVillains]([MinionId], [VillainId])
                                                    	VALUES
                                                    		(
                                                    			(	SELECT [Id] FROM [Minions]
                                                    				WHERE [Name] = @minionName), (
                                                    											SELECT [Id] FROM [Villains]
                                                    											WHERE [Name] = @villainName)
                                                    		)", sqlConnection);
            sqlCommand07.Parameters.AddWithValue("@minionName", minionName);
            sqlCommand07.Parameters.AddWithValue("@villainName", villainName);
            sqlCommand07.ExecuteNonQuery();
            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            return output.ToString().TrimEnd();
        }
    }
}
