namespace BureauAppServiceService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public string ProjectStageID { get; set; }

        public string ProjectManager { get; set; }

        public DateTime? ProjectDeadline { get; set; }

        [StringLength(10)]
        public string Client { get; set; }
    }
}
