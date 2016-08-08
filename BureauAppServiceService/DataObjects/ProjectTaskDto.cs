using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauAppServiceService.DataObjects
{
    public class ProjectTaskDto : EntityData
    {
        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public string StageID { get; set; }

        public string TaskPrecedence { get; set; }

        public string ProjectID { get; set; }

        public string PersonnellID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public string TaskStatus { get; set; }
    }
}