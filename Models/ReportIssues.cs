using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ReportIssues
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Characters required")]
        public string ProjectName { get; set; }
        public Cat? Catagory { get; set; }

        public Reproduce? Reproducibility { get; set; }

        public Severe? Severity { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Min 10 Characters required")]
        public string Summary { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Min 10 Characters required")]
        public string Description { get; set; }

        public string PhotoPath { get; set; }
        
    }
}
