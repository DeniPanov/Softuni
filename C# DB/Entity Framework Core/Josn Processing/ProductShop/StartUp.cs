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
                string input = File.ReadAllText(@"./../../../Datasets/products.json");

                string result = ImportProducts(db, input);

                Console.WriteLine(result);
            }

        }

        //p01 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //p02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
    }
}