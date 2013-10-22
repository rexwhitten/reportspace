using System;

namespace ReportSpace.CustomerDashboard.Core
{
    public interface IModelEntity
    {
        DateTime Created { get; set; }

        DateTime Updated { get; set; }  
    }
}
