namespace SoftUni
{
    using System;
    using System.Text;
    using System.Linq;

    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            string result = RemoveTown(context);

            Console.WriteLine(result);
        }

        //p03 -	Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //p04 - Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var empsWithSalaryOver50000 = context
                .Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000);

            var result = new StringBuilder();

            foreach (var e in empsWithSalaryOver50000)
            {
                result.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //p05 - Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var empsFromResearchAndDevelopment = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var e in empsFromResearchAndDevelopment)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //p06 - Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);


            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToList();

            var result = new StringBuilder();

            foreach (var a in addresses)
            {
                result.AppendLine(a.AddressText);
            }

            return result.ToString().TrimEnd();
        }

        //p07 - Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate,
                        ProjectEndDate = ep.Project.EndDate
                    })
                })
                .Take(10);

            var result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string startDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDate = project.ProjectEndDate.HasValue
                        ? project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                        : "not finished";

                    result.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return result.ToString().TrimEnd();
        }

        //p08 - Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addressesByTown = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                .Select(t => new
                {
                    t.AddressText,
                    TownName = t.Town.Name,
                    EmployeesCount = t.Employees.Count()
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var a in addressesByTown)
            {
                result.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return result.ToString().TrimEnd();
        }

        //p09 - Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var emp147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name
                    })
                .OrderBy(p => p.ProjectName)
                });

            var result = new StringBuilder();

            foreach (var e in emp147)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.Projects)
                {
                    result.AppendLine($"{p.ProjectName}");
                }
            }

            return result.ToString().TrimEnd();
        }

        //p10 - Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        e.JobTitle
                    })
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var d in departments)
            {
                result.AppendLine($"{d.DepartmentName} – {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    result.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }

        //p11 - Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            string dateFormat = "M/d/yyyy h:mm:ss tt";

            var last10projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString(dateFormat)
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var p in last10projects)
            {
                result.AppendLine(p.Name)
                    .AppendLine(p.Description)
                    .AppendLine(p.StartDate);
            }

            return result.ToString().TrimEnd();
        }

        //p12 - Increase Salaries                                                  
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var luckyEmployees = context
                .Employees
                .Where(d => d.Department.Name == "Engineering"
                         || d.Department.Name == "Tool Design"
                         || d.Department.Name == "Marketing"
                         || d.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);
 
            var result = new StringBuilder();

            foreach (var l in luckyEmployees)
            {
                l.Salary *= 1.12m;

                result.AppendLine($"{l.FirstName} {l.LastName} (${l.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }

        //p13 - Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesStartingWitSa = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var e in employeesStartingWitSa)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }

        //p14 - Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            Project projectToDelete = context
                .Projects.Find(2);

            var projectFromMappingTable = context
                .EmployeesProjects
                .Where(p => p.ProjectId == 2);

            foreach (var p in projectFromMappingTable)
            {
                context.EmployeesProjects.Remove(p);
            }

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context
                .Projects
                .Take(10)
                .Select(p => new
                {
                    ProjectName = p.Name
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var p in projects)
            {
                result.AppendLine(p.ProjectName);
            }

            return result.ToString().TrimEnd();
        }

        //p15 - Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            string townName = "Seattle";

            context.Employees
                .Where(e => e.Address.Town.Name == townName)
                .ToList()
                .ForEach(e => e.AddressId = null);

            int addressesCount = context.Addresses
                .Where(a => a.Town.Name == townName)
                .Count();

            context.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList()
                .ForEach(a => context.Addresses.Remove(a));

            context.Towns
                .Remove(context.Towns
                    .SingleOrDefault(t => t.Name == townName));

            context.SaveChanges();

            result.AppendLine($"{addressesCount} {(addressesCount == 1 ? "address" : "addresses")} in {townName} {(addressesCount == 1 ? "was" : "were")} deleted");

            return result.ToString().TrimEnd();
            }
        }
    }
