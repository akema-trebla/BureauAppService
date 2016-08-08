namespace BureauAppServiceService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Levels
    {
        [Key]
        [Column(Order = 0)]
        public int User_LevelID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "text")]
        public string User_Level_Name { get; set; }

        [Column(TypeName = "text")]
        public string User_Level_Description { get; set; }
    }
}
