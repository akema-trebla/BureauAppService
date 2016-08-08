namespace BureauAppServiceService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ghana_Districts
    {
        [Key]
        public int Ghana_DistrictID { get; set; }

        [Column("District Name")]
        [StringLength(255)]
        public string District_Name { get; set; }

        public double? RegionID { get; set; }
    }
}
