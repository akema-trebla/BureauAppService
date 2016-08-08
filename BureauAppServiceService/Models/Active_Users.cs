namespace BureauAppServiceService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Active_Users
    {
        [Key]
        public int Active_UserID { get; set; }

        public string User_Name { get; set; }

        [Column(TypeName = "text")]
        public string User_Level { get; set; }

        public string Login_Time { get; set; }

        [Column(TypeName = "text")]
        public string Column1 { get; set; }

        [Column(TypeName = "text")]
        public string Column2 { get; set; }

        [Column(TypeName = "text")]
        public string Column3 { get; set; }
    }
}
