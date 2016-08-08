namespace BureauAppServiceService.Models
{
    using Microsoft.Azure.Mobile.Server.Tables;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        public int ActivityID { get; set; }

        public DateTime? Time_Stamp { get; set; }

        public DateTime? Activity_Date { get; set; }

        public string Person { get; set; }

        public string Project { get; set; }

        public string Activity_Type { get; set; }

        public string Customer { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal? Activity_Cost { get; set; }

        [Column(TypeName = "money")]
        public decimal? Activity_Revenue { get; set; }

        [Column(TypeName = "money")]
        public decimal? Activity_Cash_Received { get; set; }

        [Column(TypeName = "money")]
        public decimal? Activity_Cash_Paid { get; set; }

        public string txtDate { get; set; }

        public string TaskID { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Index]
        [TableColumn(TableColumnType.CreatedAt)]
        public DateTimeOffset? CreatedAt { get; set; }

        [TableColumn(TableColumnType.Deleted)]
        public bool Deleted { get; set; }

        //[Index]
        //[TableColumn(TableColumnType.Id)]
        //[MaxLength(36)]
        //public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [TableColumn(TableColumnType.UpdatedAt)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [TableColumn(TableColumnType.Version)]
        [Timestamp]
        public byte[] Version { get; set; }
    }
}
