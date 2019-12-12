namespace TeisterMask.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using Data;
    using TeisterMask.DataProcessor.ExportDto;

    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context
                .Projects
                .Where(p => p.Tasks.Any())
                .Select(p => new ProjectDto
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate != null
                                    ? "Yes"
                                    : "No",
                    Tasks = p.Tasks.Select(t => new ExportTaskDto
                    {
                        Name = t.Name,
                        LabelType = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProjectDto[]),
                new XmlRootAttribute("Projects"));

            var result = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            serializer.Serialize(new StringWriter(result), projects, namespaces);

            return result.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(t => t.Task.OpenDate >= date)
                    .OrderByDescending(t => t.Task.DueDate)
                    .ThenBy(t => t.Task.Name)
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString()
                    })
                    .ToList()
                })
                .ToList()
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return jsonResult;
        }
    }
}