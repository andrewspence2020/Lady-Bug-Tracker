using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BugTracker.Models;
using Microsoft.AspNetCore.Http;

namespace BugTracker.ViewModels
{
    public class ReportIssuesCreateViewModel
    {
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

        public IFormFile Photo { get; set; }
    }
}
