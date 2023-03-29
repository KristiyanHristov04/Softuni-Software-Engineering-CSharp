using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Common;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [Required]
        [RegularExpression(GlobalConstants.TruckRegistrationNumberRegularExpression)]
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(GlobalConstants.TruckVinNumberLength)]
        [XmlElement("VinNumber")]
        public string VinNumber { get; set; }

        [Required]
        [Range(GlobalConstants.TruckTankCapacityMin, GlobalConstants.TruckTankCapacityMax)]
        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }

        [Required]
        [Range(GlobalConstants.TruckCargoCapacityMin, GlobalConstants.TruckCargoCapacityMax)]
        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [Required]
        public int CategoryType { get; set; }

        [Required]
        public int MakeType { get; set; }
    }
}
