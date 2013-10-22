namespace ReportSpace.CustomerDashboard.Core.Models
{
    using System.Collections.Generic;

    public interface IRoleBased : IIdentifiable
    {
        ICollection<Role> Roles { get; set; }
    }
}