using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentCellsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        public CellDto[] Cells { get; set; }
    }
}
