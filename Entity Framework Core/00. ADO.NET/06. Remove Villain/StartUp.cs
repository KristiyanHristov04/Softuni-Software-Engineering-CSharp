using System;
using System.Data.SqlClient;

namespace RemoveVillain
{
    internal class StartUp
    {
        private static SqlConnection dbCon;
        private static SqlTransaction transaction;

        static void Main()
        {
            Reader reader = new Reader();
            string connectionString = reader.ReadConnectionString();
            int villainId = int.Parse(reader.ReadUserInput());

            using (dbCon = new SqlConnection(connectionString))
            {
                dbCon.Open();
                string output = null;
                try
                {
                    transaction = dbCon.BeginTransaction();
                    output = RemoveVillainAndReleaseMinions(villainId);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
                Console.WriteLine(output);
                dbCon.Close();
            }
        }

        static string RemoveVillainAndReleaseMinions(int villainId)
        {
            string villainName = GetVillainName(villainId);
            if (string.IsNullOrEmpty(villainName)) return "No such villain was found.";
            
            int countMinionsReleased = ReleaseTheVillainsMinions(villainId);
            RemoveVillain(villainId);

            return $"{villainName} was deleted." + Environment.NewLine +
                   $"{countMinionsReleased} minions were released.";
        }

        static string GetVillainName(int villainId)
        {
            string checkExistingVillainIdQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";            
            SqlCommand cmd = new SqlCommand(checkExistingVillainIdQuery, dbCon, transaction);
            cmd.Parameters.AddWithValue("@villainId", villainId);
            
            string villainName = (string)cmd.ExecuteScalar();
            return villainName;
        }

        static int ReleaseTheVillainsMinions(int villainId)
        {
            string releaseMinionsQuery = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";
            SqlCommand cmd = new SqlCommand(releaseMinionsQuery, dbCon, transaction);
            cmd.Parameters.AddWithValue("@villainId", villainId);            
            return cmd.ExecuteNonQuery();
        }

        static void RemoveVillain(int villainId)
        {
            string removeVillainQuery = @"DELETE FROM Villains WHERE Id = @villainId";
            SqlCommand cmd = new SqlCommand(removeVillainQuery, dbCon, transaction);
            cmd.Parameters.AddWithValue("villainId", villainId);            
            cmd.ExecuteNonQuery();
        }
    }
}
