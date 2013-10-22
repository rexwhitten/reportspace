namespace ReportSpace.CustomerDashboard.Core.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MASFORW")]
    public class Client : INamed, IIdentifiable
    {
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("ADDR")]
        public string Address { get; set; }

        public ICollection<UserProfile> Users { get; set; }

        public Client()
        {
            Users = new Collection<UserProfile>();
        }
    }
}