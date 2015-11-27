namespace Affecto.AuditTrail.Store.Model
{
    public class AuditTrailTextFilterParameter 
    {
        public AuditTrailTextFilterOperator FilterOperator { get; set; }
        public string FilterValue { get; set; }
    }
}