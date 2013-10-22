namespace ReportSpace.CustomerDashboard.Core.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("webpages_Roles")]
    public class Role : IIdentifiable, INamed
    {
        [Key]
        [Column("RoleId")]
        public int Id { get; set; }
        
        [StringLength(256)]
        [Required]
        [Column("RoleName")]
        public string Name { get; set; }
        
        public virtual ICollection<UserProfile> UserProfiles { get; set; }

        public virtual ICollection<Report> Reports { get; set; } 

        public Role()
        {
            UserProfiles = new Collection<UserProfile>();
            Reports = new Collection<Report>();
        }
    }
}