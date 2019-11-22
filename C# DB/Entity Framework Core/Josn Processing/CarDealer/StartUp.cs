namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;

    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new CarDealerContext())
            {
                string path = @"./../../../Datasets/sales-discounts.json";
                string content = GetSalesWithAppliedDiscount(db);

                File.WriteAllText(path, content);
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
            var carsDto = JsonConvert.DeserializeObject<CarInsertDto[]>(inputJson);

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var partCar = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };
                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

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

        //p13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //p14 - Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)//false?
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                })
                .ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //p15 - Export Cars From Make Toyota 
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotas = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            string json = JsonConvert.SerializeObject(toyotas);

            return json;
        }

        //p16 - Export Local Suppliers 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        //p17 - Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },

                    parts = c.PartCars
                        .Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = $"{p.Part.Price:f2}"
                        })
                })
                .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //18 - Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var output = context
             .Customers
             .Where(c => c.Sales.Any())
             .Select(c => new
             {
                 FullName = c.Name,
                 BoughtCars = c.Sales.Count,
                 SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price))
             })
             .OrderByDescending(x => x.SpentMoney)
             .ThenByDescending(x => x.BoughtCars)
             .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonProducts = JsonConvert.SerializeObject(output, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            });
            return jsonProducts;
        }

        //p19 - Export Sales With Applied Discount 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var output = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },

                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(x => x.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(x => x.Part.Price) * ((100m - s.Discount) / 100m):f2}"
                })
                .Take(10)
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(output, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });

            return jsonProducts;
        }
    }
}