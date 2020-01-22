using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class SQLReportIssuesRepository : IReportIssuesRepository
    {
        private readonly AppDbContext context;

        public SQLReportIssuesRepository(AppDbContext context) {
            this.context = context;
        }
        public ReportIssues Add(ReportIssues reportIssues)
        {
            context.ReportIssues.Add(reportIssues);
            context.SaveChanges();
            return reportIssues;
            
        }

        public IEnumerable<ReportIssues> GetAllReportIssues()
        {
            return context.ReportIssues;
        }

        public ReportIssues GetReportIssues(int Id)
        {
            return context.ReportIssues.Find(Id);
        }

        public ReportIssues Update(ReportIssues ReportIssuesChanges)
        {
            var reportIssues = context.ReportIssues.Attach(ReportIssuesChanges);
            reportIssues.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return ReportIssuesChanges;
        }
    }
}
