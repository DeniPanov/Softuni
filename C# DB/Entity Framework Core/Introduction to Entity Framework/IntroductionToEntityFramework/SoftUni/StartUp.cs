namespace SoftUni
{
    using System;
    using System.Text;
    using System.Linq;

    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            string result = GetEmployeesInPeriod(context);

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

        //p08 - 
    }
}
