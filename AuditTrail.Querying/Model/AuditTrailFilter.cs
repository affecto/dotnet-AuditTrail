using System.Collections.Generic;

namespace Affecto.AuditTrail.Querying.Model
{
    public class AuditTrailFilter 
    {
        public List<AuditTrailDateFilterParameter> TimestampFilterParameters { get; set; }
        public AuditTrailFilterLogic TimestampFilterLogic { get; set; }

        public List<AuditTrailTextFilterParameter> SummaryFilterParameters { get; set; }
        public AuditTrailFilterLogic SummaryFilterLogic { get; set; }

        public List<AuditTrailTextFilterParameter> SubjectNameFilterParameters { get; set; }
        public AuditTrailFilterLogic SubjectNameFilterLogic { get; set; }

        public List<AuditTrailTextFilterParameter> UserNameFilterParameters { get; set; }
        public AuditTrailFilterLogic UserNameFilterLogic { get; set; }

        public List<AuditTrailSortParameter> SortParameters { get; set; }

        public long Skip { get; set; }
        public long Take { get; set; }

        public AuditTrailFilter()
        {
            TimestampFilterParameters = new List<AuditTrailDateFilterParameter>();
            SummaryFilterParameters = new List<AuditTrailTextFilterParameter>();
            SubjectNameFilterParameters = new List<AuditTrailTextFilterParameter>();
            UserNameFilterParameters = new List<AuditTrailTextFilterParameter>();
            SortParameters = new List<AuditTrailSortParameter>();
        }
    }
}