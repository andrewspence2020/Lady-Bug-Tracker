using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Name cannot exceed Characters")]
        public string ProjectName { get; set; }
        
        [Required]
        public Stats? Status { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Min 10 Characters required")]
        public string Description { get; set; }

        public string PhotoPath { get; set; }


    }
}
