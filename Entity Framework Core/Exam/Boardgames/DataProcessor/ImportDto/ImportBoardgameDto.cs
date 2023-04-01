using Boardgames.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [Required]
        [MinLength(GlobalConstants.BoardgameNameMinLength)]
        [MaxLength(GlobalConstants.BoardgameNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.BoardgameRatingMin, GlobalConstants.BoardgameRatingMax)]
        [XmlElement("Rating")]
        public double Rating { get; set; }

        [Required]
        [Range(GlobalConstants.BoardgameYearPublishedMin, GlobalConstants.BoardgameYearPublishedMax)]
        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; }
    }
}
