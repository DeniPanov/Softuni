using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{

  //  <? xml version="1.0" encoding="utf-8"?>
  //  <suppliers>
  //<suplier id = "2" name="VF Corporation" parts-count="3" />
  //<suplier id = "5" name="Saks Inc" parts-count="2" />
  //...
  //  </suppliers>

    [XmlType("suplier")]
    public class LocalSuppliers
    {
        [XmlAttribute("id")]
        public int id { get; set; }

        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("parts-count")]
        public int partsCount { get; set; }
    }
}
