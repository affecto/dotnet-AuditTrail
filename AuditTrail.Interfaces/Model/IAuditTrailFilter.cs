using System.Collections.Generic;

namespace Affecto.AuditTrail.Interfaces.Model
{
    public interface IAuditTrailFilter
    {
        List<IAuditTrailDateFilterParameter> TimestampFilterParameters { get; set; }
        AuditTrailFilterLogic TimestampFilterLogic { get; set; }

        List<IAuditTrailTextFilterParameter> SummaryFilterParameters { get; set; }
        AuditTrailFilterLogic SummaryFilterLogic { get; set; }

        List<IAuditTrailTextFilterParameter> SubjectNameFilterParameters { get; set; }
        AuditTrailFilterLogic SubjectNameFilterLogic { get; set; }

        List<IAuditTrailTextFilterParameter> UserNameFilterParameters { get; set; }
        AuditTrailFilterLogic UserNameFilterLogic { get; set; }

        List<IAuditTrailSortParameter> SortParameters { get; set; }

        long Skip { get; set; }
        long Take { get; set; }
    }
}