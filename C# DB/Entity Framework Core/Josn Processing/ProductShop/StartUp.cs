namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    using ProductShop.Data;
    using ProductShop.Models;
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                string input = File.ReadAllText(@"./../../../Datasets/users.json");

                string result = ImportUsers(db, input);

                Console.WriteLine(result);
            }

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}