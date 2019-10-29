namespace ChangeTownNameCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string countryName = Console.ReadLine();
                List<string> townsToUpper = new List<string>();

                string townsQuery = @"UPDATE Towns   SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                string contryQuery = @"SELECT t.Name    FROM Towns as t   JOIN Countries AS c ON c.Id = t.CountryCode  WHERE c.Name = @countryName";

                using (SqlCommand command = new SqlCommand(townsQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand(contryQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            townsToUpper.Add((string)reader[0]);
                        }

                        if (townsToUpper.Count == 0)
                        {
                            Console.WriteLine("No town names were affected.");
                            return;
                        }

                        Console.WriteLine($"{townsToUpper.Count} town names were affected.");
                        Console.Write("[");
                        Console.Write(string.Join(",", townsToUpper));
                        Console.WriteLine("]");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
