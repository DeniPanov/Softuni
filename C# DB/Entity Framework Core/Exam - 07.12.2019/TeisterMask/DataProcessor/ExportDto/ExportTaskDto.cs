namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using TeisterMask.Data.Models.Enums;

    [XmlType("Task")]
    public class ExportTaskDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("Label")]
        public string LabelType { get; set; }
    }
}