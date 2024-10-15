using Server.Database;
using Server.Modal;
using System.Linq;

namespace Server.Service
{
    public class ReportService
    {
        private readonly AppDbContext _context;

        public ReportService(AppDbContext context)
        {
            _context = context;
        }

        // Create a new report in the database
        public void Create(Report reportObj)
        {
            _context.Report.Add(reportObj); // Changed to singular "Report"
            _context.SaveChanges();
        }

        // Read: Get a report by its ID
        public Report GetReport(long reportId)
        {
            return _context.Report.FirstOrDefault(r => r.Id == reportId); // Changed to singular "Report"
        }

        // Read: Get all reports
        public Report[] GetAllReports()
        {
            return _context.Report.ToArray(); // Changed to singular "Report"
        }

        // Update: Update an existing report
        public void Update(Report updatedReport)
        {
            var existingReport = _context.Report.FirstOrDefault(r => r.Id == updatedReport.Id); // Changed to singular "Report"
            if (existingReport != null)
            {
                existingReport.Address = updatedReport.Address;
                existingReport.Description = updatedReport.Description;
                existingReport.Email = updatedReport.Email;

                _context.Report.Update(existingReport); // Changed to singular "Report"
                _context.SaveChanges();
            }
        }

        // Delete: Delete a report by its ID
        public void Delete(long reportId)
        {
            var report = _context.Report.FirstOrDefault(r => r.Id == reportId); // Changed to singular "Report"
            if (report != null)
            {
                _context.Report.Remove(report); // Changed to singular "Report"
                _context.SaveChanges();
            }
        }
    }
}
