using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));
            using (var db = new CarDealerContext())
            {
                //var inputXml = File.ReadAllText("./../../../Datasets/suppliers.xml");//09
                //var result = ImportSuppliers(db, inputXml);//09

                //var inputXml = File.ReadAllText("./../../../Datasets/parts.xml");//10
                //var result = ImportParts(db, inputXml);//10

                //var inputXml = File.ReadAllText("./../../../Datasets/cars.xml");//11
                //var result = ImportCars(db, inputXml);//11

                //var inputXml = File.ReadAllText("./../../../Datasets/customers.xml");//12
                //var result = ImportCustomers(db, inputXml);//12

                //var inputXml = File.ReadAllText("./../../../Datasets/sales.xml");//13
                //var result = ImportSales(db, inputXml);//13

                //var result = GetCarsWithDistance(db);//14

                //var result = GetCarsFromMakeBmw(db);//15

                //var result = GetLocalSuppliers(db);//16

                //var result = GetCarsWithTheirListOfParts(db);//17

                //var result = GetTotalSalesByCustomer(db);//18

                var result = GetSalesWithAppliedDiscount(db);//19

                Console.WriteLine(result);
            }
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(InportSuppilerDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (InportSuppilerDto[])serializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = new Supplier
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PartsDto[]), new XmlRootAttribute("Parts"));
            var partsDto = (PartsDto[])serializer.Deserialize(new StringReader(inputXml));
            var parts = new List<Part>();

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            foreach (var partDto in partsDto)
            {
                if (supplierIds.Contains(partDto.SupplierId))
                {
                    var part = new Part
                    {
                        Name = partDto.Name,
                        Price = partDto.Price,
                        Quantity = partDto.Quantity,
                        SupplierId = partDto.SupplierId
                    };
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsDto[]), new XmlRootAttribute("Cars"));
            var carDtos = (CarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));
            var cars = new List<Car>();

            var validPartIds = context.Parts.Select(x => x.Id).ToList();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var uniquePartIds = carDto.PartCars.Select(x => x.Id).Distinct();
                var partCars = new List<PartCar>();

                foreach (var partId in uniquePartIds)
                {
                    if (!validPartIds.Contains(partId))
                    {
                        continue;
                    }

                    partCars.Add(new PartCar
                    {
                        PartId = partId,
                        Car = car
                    });
                }

                car.PartCars = partCars;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomersDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (CustomersDto[])serializer.Deserialize(new StringReader(inputXml));
            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = new Customer
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                };
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SalesDto[]), new XmlRootAttribute("Sales"));
            var salesDto = (SalesDto[])serializer.Deserialize(new StringReader(inputXml));
            var sales = new List<Sale>();
            var carIds = context.Cars.Select(x => x.Id).ToList();

            foreach (var saleDto in salesDto)
            {
                if (carIds.Contains(saleDto.carId))
                {
                    var sale = new Sale
                    {
                        CarId = saleDto.carId,
                        CustomerId = saleDto.customerId,
                        Discount = saleDto.discount
                    };
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                //.Select(c => new CarsDtoExport
                //{
                //    make = c.Make,
                //    model = c.Model,
                //    travelledDistance = c.TravelledDistance
                //})
                //.OrderBy(c => c.make)
                //.ThenBy(c => c.model)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(CarsDtoExport[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
               .Cars
               .Where(c => c.Make == "BMW" )
               .Select(c => new CarsFromMakeBmwExport
               {
                   id = c.Id,
                   model = c.Model,
                   travelledDistance = c.TravelledDistance
               })
               .OrderBy(c => c.model)
               .ThenByDescending(c => c.travelledDistance)
               .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(CarsFromMakeBmwExport[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var supplier = context
              .Suppliers
              .Where(s=>s.IsImporter == false)
              .Select(s => new LocalSuppliers
              {
                  id = s.Id,
                  name = s.Name,
                  partsCount = s.Parts.Count()
              })
              .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(LocalSuppliers[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(new StringWriter(sb), supplier, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new CarsWithPartsDtoExport
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(p => new PartsDtoExport
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarsWithPartsDtoExport[]),
                new XmlRootAttribute("cars"));

            var result = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return result.ToString().TrimEnd();
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerDtoExport
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CustomerDtoExport[]),
                new XmlRootAttribute("customers"));

            var result = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, customers, namespaces);
            }

            return result.ToString().TrimEnd();
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new SalesDtoExport
                {
                    Cars = new CarsWithPartsDtoExport
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },

                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price) - (s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount) / 100
                })
                .ToArray();

            var serizlizer = new XmlSerializer(typeof(SalesDtoExport[]),
                new XmlRootAttribute("sales"));

            var result = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(result))
            {
                serizlizer.Serialize(writer, sales, namespaces);
            }

            return result.ToString().TrimEnd();
        }

    }
}
