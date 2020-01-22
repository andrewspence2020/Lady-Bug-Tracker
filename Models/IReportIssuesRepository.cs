using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public interface IReportIssuesRepository
    {
        ReportIssues GetReportIssues(int Id);
        IEnumerable<ReportIssues> GetAllReportIssues();

        ReportIssues Add(ReportIssues reportIssues);

        ReportIssues Update(ReportIssues ReportIssuesChanges);

       

    }
}
