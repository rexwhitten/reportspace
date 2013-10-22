namespace ReportSpace.CustomerDashboard.Core.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class EntityBase : IModelEntity, IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated { get; set; }
    }
}