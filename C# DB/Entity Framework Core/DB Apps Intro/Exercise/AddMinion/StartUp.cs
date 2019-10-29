using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Introduction_to_DB_Apps;

namespace Problem04
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> minion = Console.ReadLine().Split().ToList();
            List<string> villains = Console.ReadLine().Split().ToList();

            string minionName = minion[1];
            int minioAge = int.Parse(minion[2]);
            string tower = minion[3];

            string villainsName = villains[1];

            int? idTown = null;
            int? idMinion = null;
            int? idVillains = null;


            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionDatabase))
            {
                connection.Open();

                string villainsQuery = @"SELECT Id FROM Villains WHERE Name = @Name";
                string townsQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
                string minionQuery = @"SELECT Id FROM Minions WHERE Name = @Name";
                string minionsVillainsInsert = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";


                using (SqlCommand command = new SqlCommand(townsQuery, connection))
                {
                    command.Parameters.AddWithValue("@townName", tower);

                    int? id = (int?)command.ExecuteScalar();

                    if (id == null)
                    {
                        string townsInsert = @"INSERT INTO Towns (Name) VALUES (@townName)";

                        using (SqlCommand command1 = new SqlCommand(townsInsert, connection))
                        {
                            command1.Parameters.AddWithValue("@townName", tower);

                            command1.ExecuteNonQuery();

                            Console.WriteLine($"Town {tower} was added to the database.");
                        }
                    }

                    idTown = (int)command.ExecuteScalar();
                }

                using (SqlCommand command = new SqlCommand(minionQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", minionName);

                    int? id = (int?)command.ExecuteScalar();

                    if (id == null)
                    {
                        string townsInsert = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

                        using (SqlCommand command1 = new SqlCommand(townsInsert, connection))
                        {
                            command1.Parameters.AddWithValue("@name", minionName);
                            command1.Parameters.AddWithValue("@age", minioAge);
                            command1.Parameters.AddWithValue("@townId", idTown);

                            command1.ExecuteNonQuery();

                            Console.WriteLine($"Minion {minionName} was added to the database.");
                        }
                    }

                    idMinion = (int)command.ExecuteScalar();
                }

                using (SqlCommand command = new SqlCommand(villainsQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", villainsName);
               
                    int? id = (int?)command.ExecuteScalar();
               
                    if (id == null)
                    {
                        string villainsInsert = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
               
                        using (SqlCommand command1 = new SqlCommand(villainsInsert, connection))
                        {
                            command1.Parameters.AddWithValue("@villainName", villainsName);
               
                            command1.ExecuteNonQuery();

                            Console.WriteLine($"Villain {villainsName} was added to the database.");
                        }
                    }

                    idVillains = (int)command.ExecuteScalar();
                }

                using (SqlCommand command = new SqlCommand(minionsVillainsInsert, connection))
                {
                    command.Parameters.AddWithValue("@villainId", idVillains);
                    command.Parameters.AddWithValue("@minionId", idMinion);

                    command.ExecuteNonQuery();

                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainsName}.");
                }
            }  

        }
    }
}
