namespace BureauAppServiceService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payrollrun")]
    public partial class Payrollrun
    {
        [Key]
        [Column(Order = 0)]
        public int PayrollrunID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Basic_Salary { get; set; }

        [Column(TypeName = "money")]
        public decimal? PAYE { get; set; }

        [Column("SSNIT(5%)", TypeName = "money")]
        public decimal? SSNIT_5__ { get; set; }

        [Column(TypeName = "money")]
        public decimal? Net_Salary { get; set; }
    }
}
