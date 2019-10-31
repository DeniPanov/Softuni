namespace SoftUni
{
    using System;
    using System.Text;
    using System.Linq;

    using SoftUni.Data;

    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            string result = GetEmployeesFullInformation(context);

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
    }
}
