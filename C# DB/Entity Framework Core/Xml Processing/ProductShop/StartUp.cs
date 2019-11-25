namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.Dtos.Import;

    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                string path = @"./../../../Datasets/products.xml";
                string inputXml = File.ReadAllText(path);

                string result = ImportProducts(db, inputXml);

                Console.WriteLine(result);
            }
        }

        //p01 - Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUserDto[])
                , new XmlRootAttribute("Users"));

            ImportUserDto[] userDtos;

            using (var reader = new StringReader(inputXml))
            {
                userDtos = (ImportUserDto[])
                    serializer.Deserialize(reader);
            }

            var usersToImportToDb = new List<User>();

            foreach (var user in userDtos)
            {
                User currentUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age
                };

                usersToImportToDb.Add(currentUser);
            }

            context.Users.AddRange(usersToImportToDb);
            context.SaveChanges();

            return $"Successfully imported {usersToImportToDb.Count}";
        }

        //p02 - Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportProductDto[])
                , new XmlRootAttribute("Products"));

            ImportProductDto[] productDtos;

            using (var reader = new StringReader(inputXml))
            {
                productDtos = (ImportProductDto[])
                    serializer.Deserialize(reader);
            }

            var productsToImport = new List<Product>();

            foreach (var dto in productDtos)
            {
                Product product = new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    SellerId = dto.SellerId,
                    BuyerId = dto.BuyerId
                };

                productsToImport.Add(product);
            }

            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return $"Successfully imported {productsToImport.Count}";
        }

        //p03 - Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportCategoryDto>),
                new XmlRootAttribute("Categories"));

            var categories = new List<ImportCategoryDto>();

            using (var reader = new StringReader(inputXml))
            {
                categories = ((List<ImportCategoryDto>)
                    serializer.Deserialize(reader))
                    .Where(c => c.Name != null)
                    .ToList();
            }

            var categoriesToImport = new List<Category>();

            foreach (var category in categories)
            {
                Category currentCategory = new Category
                {
                    Name = category.Name
                };

                categoriesToImport.Add(currentCategory);
            }

            context.Categories.AddRange(categoriesToImport);
            context.SaveChanges();

            return $"Successfully imported {categoriesToImport.Count}";
        }

    }
}