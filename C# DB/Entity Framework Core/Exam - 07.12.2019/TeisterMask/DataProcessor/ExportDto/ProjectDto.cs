namespace TeisterMask.DataProcessor.ExportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ProjectDto
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [Required]
        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; } //nullable DateTime

        public ExportTaskDto[] Tasks { get; set; }
    }
}
