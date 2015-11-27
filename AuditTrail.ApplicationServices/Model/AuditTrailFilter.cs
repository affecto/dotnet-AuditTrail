using System.Collections.Generic;
using Affecto.AuditTrail.Interfaces.Model;

namespace Affecto.AuditTrail.ApplicationServices.Model
{
    internal class AuditTrailFilter : IAuditTrailFilter
    {
        public List<IAuditTrailDateFilterParameter> TimestampFilterParameters { get; set; }
        public AuditTrailFilterLogic TimestampFilterLogic { get; set; }

        public List<IAuditTrailTextFilterParameter> SummaryFilterParameters { get; set; }
        public AuditTrailFilterLogic SummaryFilterLogic { get; set; }

        public List<IAuditTrailTextFilterParameter> SubjectNameFilterParameters { get; set; }
        public AuditTrailFilterLogic SubjectNameFilterLogic { get; set; }

        public List<IAuditTrailTextFilterParameter> UserNameFilterParameters { get; set; }
        public AuditTrailFilterLogic UserNameFilterLogic { get; set; }

        public List<IAuditTrailSortParameter> SortParameters { get; set; }

        public long Skip { get; set; }
        public long Take { get; set; }

        public AuditTrailFilter()
        {
            TimestampFilterParameters = new List<IAuditTrailDateFilterParameter>();
            SummaryFilterParameters = new List<IAuditTrailTextFilterParameter>();
            SubjectNameFilterParameters = new List<IAuditTrailTextFilterParameter>();
            UserNameFilterParameters = new List<IAuditTrailTextFilterParameter>();
            SortParameters = new List<IAuditTrailSortParameter>();
        }
    }
}