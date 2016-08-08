namespace BureauAppServiceService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project Stages")]
    public partial class Project_Stage
    {
        [Key]
        public int StageID { get; set; }

        public string StageName { get; set; }

        public string StageDescription { get; set; }
    }
}
