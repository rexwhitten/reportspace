namespace ReportSpace.CustomerDashboard.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ReportViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must give a name to the report")]
        public string Name { get; set; }

        public string Description { get; set; }
        
        [Required(ErrorMessage = "You must select a report")]
        public string Path { get; set; }

        [Required(ErrorMessage = "You must select a category")]
        public string Category { get; set; }

        public bool OpensOnSearch { get; set; }

        public bool IsHidden { get; set; }

        public string Roles { get; set; }

        public IList<int> RoleIds
        {
            get
            {
                var roles = Roles ?? string.Empty;
                return roles.Split(',').Where(n => !string.IsNullOrEmpty(n)).Select(n => Convert.ToInt32(n)).ToList();
            }
        }
    }
}