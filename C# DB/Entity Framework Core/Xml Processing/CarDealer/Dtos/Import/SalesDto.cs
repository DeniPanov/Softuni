using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Sale")]
    public class SalesDto
    {
        [XmlElement("carId")]
        public int carId { get; set; }

        [XmlElement("customerId")]
        public int customerId { get; set; }

        [XmlElement("discount")]
        public int discount { get; set; }
    }
}
