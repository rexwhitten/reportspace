namespace ReportSpace.CustomerDashboard.Core.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Report : EntityBase, IRoleBased, ICategorizable, IVisibility
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Path { get; set; }

        public ICollection<Role> Roles { get; set; }

        public bool IsDefault { get; set; }

        public bool IsHidden { get; set; }

        public Report()
        {
            Roles = new Collection<Role>();
        }
    }
}