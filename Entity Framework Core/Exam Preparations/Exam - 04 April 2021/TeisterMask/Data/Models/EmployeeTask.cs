using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        [Required]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
