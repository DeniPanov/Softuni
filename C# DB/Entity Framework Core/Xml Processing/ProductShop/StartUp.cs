namespace ProductShop
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.Dtos;
    using ProductShop.Dtos.Import;

    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                string path = @"./../../../Datasets/users.xml";
                string inputXml = File.ReadAllText(path);

                string result = ImportUsers(db, inputXml);

                Console.WriteLine(result);
            }
        }

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

    }
}