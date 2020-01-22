using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class MockReportIssuesRepository : IReportIssuesRepository
    {

        private List<ReportIssues> _reportIssuesList;

        public MockReportIssuesRepository() 
        {
            _reportIssuesList = new List<ReportIssues>()
            {
                new ReportIssues() {Id = 1,
                    ProjectName = "Bug Tracker",
                    Catagory = Cat.Mobile,
                    Severity = Severe.Crash,
                    Reproducibility = Reproduce.NotAvailible,
                    Summary ="Main Screen bootstrap won't show up",
                    Description="I tried putting the bootstrap in my project but it seems" +
                    "Not to work..Like what the hell",
                }
            };

        }

        public ReportIssues GetReportIssues(int Id)
        {
            return _reportIssuesList.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<ReportIssues> GetAllReportIssues()
        {
            return _reportIssuesList;
        }

        public ReportIssues Add(ReportIssues reportIssues)
        {
            reportIssues.Id = _reportIssuesList.Max(p => p.Id) + 1;
            _reportIssuesList.Add(reportIssues);
            return reportIssues;
        }

        public ReportIssues Update(ReportIssues ReportIssuesChanges)
        {
            ReportIssues reportIssues = _reportIssuesList.FirstOrDefault(e => e.Id == ReportIssuesChanges.Id);
            {
                reportIssues.ProjectName = ReportIssuesChanges.ProjectName;
                reportIssues.Catagory = ReportIssuesChanges.Catagory;
                reportIssues.Severity = ReportIssuesChanges.Severity;
                reportIssues.Reproducibility = ReportIssuesChanges.Reproducibility;
                reportIssues.Summary = ReportIssuesChanges.Summary;
                reportIssues.Description = ReportIssuesChanges.Description;
            }
            return reportIssues;
        }



    }
}
