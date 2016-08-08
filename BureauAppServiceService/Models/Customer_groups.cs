namespace BureauAppServiceService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer_groups
    {
        [Key]
        public int customer_group_id { get; set; }

        public string customer_group_name { get; set; }

        public string customer_group_description { get; set; }

        public string redundant_column1 { get; set; }

        public string redundant_column2 { get; set; }

        public string redundant_column3 { get; set; }
    }
}
