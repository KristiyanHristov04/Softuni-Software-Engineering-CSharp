using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class ExportCountryDto
    {
        [XmlAttribute("Country")]
        public string CountryName { get; set; }

        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
    }
}
