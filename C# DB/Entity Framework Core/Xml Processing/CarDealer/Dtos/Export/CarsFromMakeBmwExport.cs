using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class CarsFromMakeBmwExport
    {
        [XmlAttribute("id")]
        public int id { get; set; }

        [XmlAttribute("model")]
        public string model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long travelledDistance { get; set; }

    }
}
