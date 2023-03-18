using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [XmlType("Users")]
    public class UserProductOutputModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserInfoOutputModel[] Users { get; set; }
    }

    [XmlType("User")]
    public class UserInfoOutputModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductInfoOutputModel SoldProducts { get; set; }
    }

    [XmlType("SoldProducts")]
    public class SoldProductInfoOutputModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductInfoOutputModel[] Products { get; set; }
    }
}
