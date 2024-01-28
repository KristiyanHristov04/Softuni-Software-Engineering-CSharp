using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModels.Product
{
    public class ProductFormModel
    {
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }
}
