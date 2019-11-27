using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{

    [XmlType("Car")]
    public class CarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartIdDto[] PartCars { get; set; }
    }

    [XmlType("partId")]
    public class PartIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }

}
