namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new CarDealerContext())
            {
                string path = @"./../../../Datasets/customers.json";
                string inputJson = File.ReadAllText(path);

                string result = ImportCustomers(db, inputJson);

                Console.WriteLine(result);
            }
        }

        //p09 - Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";//String.Format(outputMessage,suppliers.Count());
        }

        //p10 - Import Parts 
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            var validParts = new List<Part>();
            var suppliersIds = context
                .Suppliers
                .Select(s => s.Id)
                .ToList();

            foreach (var part in parts)
            {
                if (suppliersIds.Contains(part.SupplierId))
                {
                    validParts.Add(part);
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count()}.";
        }

        //p11 - Import Cars 
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);

            Console.WriteLine(cars);
            //context.Cars.AddRange(cars);
            //context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //p12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }
    }

}