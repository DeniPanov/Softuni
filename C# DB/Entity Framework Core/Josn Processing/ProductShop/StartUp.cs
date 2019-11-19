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
                string inputJson = File.ReadAllText(@"./../../../Datasets/categories.json");

                string result = ImportCategories(db, inputJson);

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

        //p03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => string.IsNullOrWhiteSpace(c.Name) ==  false)
                .ToList();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
    }
}