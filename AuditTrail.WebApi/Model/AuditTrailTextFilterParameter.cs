namespace Affecto.AuditTrail.WebApi.Model
{
    public class AuditTrailTextFilterParameter
    {
        public AuditTrailTextFilterOperator FilterOperator { get; set; }
        public string FilterValue { get; set; }
    }
}