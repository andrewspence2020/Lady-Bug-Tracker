using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ProjectName = "Bug Tracker",
                    Status = Stats.Stable,
                    Description = "I Hate this Project"

                },
                new Project
                {
                    Id = 2,
                    ProjectName = "Employement Survey",
                    Status = Stats.Obsolete,
                    Description = "I Love this Project"
                });
            modelBuilder.Entity<ReportIssues>().HasData(
                new ReportIssues
                {
                    Id = 1,
                    ProjectName = "Facebook Clone",
                    Catagory = Cat.Mobile,
                    Severity = Severe.Major,
                    Summary = "H1 emements won't show up on the index html page",
                    Description = "Whenever I apply the h1 emements for my page I can 't seem to make it work"
                },

                new ReportIssues
                {
                    Id = 2,
                    ProjectName = "Bug Tracker",
                    Catagory = Cat.Mobile,
                    Severity = Severe.Trivial,
                    Summary = "H1 emements won't show up on the index html page",
                    Description = "Whenever I apply the h1 emements for my page I can 't seem to make it work"

              }); 
            
        }

    }
}
