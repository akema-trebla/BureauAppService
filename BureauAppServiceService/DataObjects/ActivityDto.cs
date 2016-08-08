using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauAppServiceService.DataObjects
{
    public class ActivityDto : EntityData
    {
        public DateTime? Time_Stamp { get; set; }

        public DateTime? Activity_Date { get; set; }

        public string Person { get; set; }

        public string Project { get; set; }

        public string Activity_Type { get; set; }

        public string Customer { get; set; }

        public string Description { get; set; }

        public decimal? Activity_Cost { get; set; }

        public decimal? Activity_Revenue { get; set; }

        public decimal? Activity_Cash_Received { get; set; }

        public decimal? Activity_Cash_Paid { get; set; }

        public string txtDate { get; set; }

        public string TaskID { get; set; }
    }
}