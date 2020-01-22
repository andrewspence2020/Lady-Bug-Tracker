using BugTracker.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.ViewModels
{
    public class ProjectCreateViewModel
    {

        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Characters required")]
        public string ProjectName { get; set; }

        [Required]
        public Stats? Status { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Min 10 Characters required")]
        public string Description { get; set; }

        public IFormFile Photo { get; set; }
    }
}
