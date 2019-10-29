namespace MinionNames
{
    using System;
    using InitialSetup;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            static void Main(string[] args)
            {
                int id = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
                {
                    connection.Open();

                    string villainsQuery = @"SELECT Name FROM Villains WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(villainsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        string name = (string)command.ExecuteScalar();

                        if (name == null)
                        {
                            Console.WriteLine($"No villain with ID {id} exists in the database.");
                            return;
                        }

                        Console.WriteLine($"Villain: {name}");
                    }

                    string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                    using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long row = (long)reader[0];
                                string name = (string)reader[1];
                                int age = (int)reader[2];

                                Console.WriteLine($"{row}. {name} {age}");
                            }

                            if (!reader.HasRows)
                            {
                                Console.WriteLine("(no minions)");
                            }
                        }
                    }
                }

            }
        }
    }
}
