namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [Required]
        public int ProjectionId { get; set; }

        [Required]
        [Range(typeof(decimal), "0,01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}