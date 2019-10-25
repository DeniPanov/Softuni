namespace VillianNames
{
    using System;
    using InitialSetup;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            GetAllVillainNamesAndTheCountOfTheirMinions();
        }

        private static void GetAllVillainNamesAndTheCountOfTheirMinions()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string queryText = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                        FROM Villains AS v 
                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                    GROUP BY v.Id, v.Name 
                                      HAVING COUNT(mv.VillainId) > 3 
                                    ORDER BY COUNT(mv.VillainId)";

                using (var command = new SqlCommand(queryText, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                        }
                    }
                }
            }
        }
    }
}
