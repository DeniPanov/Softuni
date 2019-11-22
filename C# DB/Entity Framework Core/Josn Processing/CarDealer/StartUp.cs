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
                string path = @"./../../../Datasets/suppliers.json";
                string inputJson = File.ReadAllText(path);

                string result = ImportSuppliers(db, inputJson);

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
    }

}