namespace ProductShop
{
    using System;
    using System.IO;
    using System.Text;
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
                string path = @"./../../../Datasets/products-in-range.json";

                string result = GetProductsInRange(db);

                File.WriteAllText(path, result);

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

        //p04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        //p05 - Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .Where(p => p.Price >= 500
                    && p.Price <= 1000)
                .Select(p => new 
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.price)
                .ToList();

            string result = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return result;
        }
    }
}