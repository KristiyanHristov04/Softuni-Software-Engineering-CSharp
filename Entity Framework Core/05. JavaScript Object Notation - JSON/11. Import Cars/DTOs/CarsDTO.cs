using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs
{
    public class CarsDTO
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        [JsonProperty("traveledDistance")]
        public long TravelledDistance { get; set; }

        public List<int> PartsId { get; set; }
    }
}
