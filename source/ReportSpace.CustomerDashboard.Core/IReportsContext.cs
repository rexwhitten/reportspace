namespace ReportSpace.CustomerDashboard.Core
{
    using System.Data.Entity;

    using ReportSpace.CustomerDashboard.Core.Models;

    public interface IReportsContext
    {
        IDbSet<Report> Reports { get; set; }

        IDbSet<Role> Roles { get; set; }

        int SaveChanges();

        void ResetPreviousDefaultReport(int currentDefaultReportId);
    }

}