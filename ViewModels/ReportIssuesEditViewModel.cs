using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.ViewModels
{
    public class ReportIssuesEditViewModel : ReportIssuesCreateViewModel
    {
        public int Id { get; set; }

        public string ExistingPhotoPath { get; set; }
        
    }
}
