using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.DataProcessor.ImportDto
{
    public class ImportGunsCountryDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
