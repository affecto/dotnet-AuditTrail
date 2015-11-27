namespace Affecto.AuditTrail.Querying.Model
{
    public class AuditTrailTextFilterParameter 
    {
        public AuditTrailTextFilterOperator FilterOperator { get; set; }
        public string FilterValue { get; set; }
    }
}